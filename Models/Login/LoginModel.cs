using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BookmarkWeb.API.Commons;
using UserTbl = BookmarkWeb.API.Database.Entities.User;
using BookmarkWeb.API.Database.Entities;
using BookmarkWeb.API.Models.Common.Schemas;
using BookmarkWeb.API.Models.Login.Schemas;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using BookmarkWeb.API.Commons.Enums;
using BookmarkWeb.API.Commons.Schemas;
using BookmarkWeb.API.Commons.CodeMaster;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Options;
using Google.Apis.Auth;

namespace BookmarkWeb.API.Models.Login
{
    public interface ILoginModel
    {
         Task<ResponseInfo> CheckAccount(UserLogin user);
         /// <summary>
        /// Lấy lại token mới trước khi token cũ hết hạn
        /// <para>Created at: 18/04/2021</para>
        /// <para>Created by: QuyPN</para>
        /// </summary>
        /// <param name="token">Thông tin token cũ</param>
        /// <returns>Dữ liệu token mới</returns>
        Task<ResponseInfo> RefreshToken(Token token);

        /// <summary>
        /// Xoá thông tin token khi logout
        /// <para>Created at: 18/04/2021</para>
        /// <para>Created by: QuyPN</para>
        /// </summary>
        /// <returns>Kết quả xoá token</returns>
        Task<ResponseInfo> RemoveToken();

        Task<ResponseInfo> RegisterAccount(UserDto user);
        Task<ResponseInfo> GetGoogleUserTokenAsync(string oauthCode);
    }
    public class LoginModel : BaseModel, ILoginModel
    {
        private readonly ILogger<LoginModel> _logger;
        private readonly GoogleOAuthSettings _googleOAuthSettings;
        private string _className = "";

        public LoginModel(
            ILogger<LoginModel> logger,
            IServiceProvider provider,
            IOptions<GoogleOAuthSettings> googleOAuthSettings
        ) : base(provider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _className = GetType().Name;
            _googleOAuthSettings = googleOAuthSettings.Value;
        }
        static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;
        public async Task<ResponseInfo> CheckAccount(UserLogin user)
        {
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");

                ResponseInfo result = new ResponseInfo();

                if (result.Code != CodeResponse.OK)
                {
                    return result;
                }

                var userDB = await _context.Users.Where(x => x.Username == user.Username || user.Username == x.Email).FirstOrDefaultAsync();

                _logger.LogInformation($"[{_className}][{method}] Kiểm tra thông tin người dùng nhập");

                if (userDB == null || (user.Password != "" && userDB.Password != Security.GetSHA256(Security.GetSimpleMD5(user.Password))))
                {
                    result.MsgNo = MSG_NO.USERNAME_OR_PASSWORD_NOT_CORRECT;
                    result.Code = CodeResponse.HAVE_ERROR;
                    return result;
                }
                else
                {
                    // Tạo token và lưu các thông tin cần thiết khi login
                    _logger.LogInformation($"[{_className}][{method}] Tạo token cho trang TRN");
                    string token = Security.GenerationJWTCode(new JwtData()
                    {
                        UserId = userDB.Id,
                        Username = userDB.Username,
                    });
                    string refreshToken = Helpers.RenderToken(userDB.Id.ToString(), 180);
                    UserToken userToken = new UserToken()
                    {
                        UserId = userDB.Id,
                        JwtToken = token,
                        RefreshToken = refreshToken,
                        ValidateToken = "",
                        Timeout = DateTimeOffset.Now.AddMinutes(Constants.API_EXPIRES_MINUTE),
                    };
                    _context.UserTokens.Add(userToken);

                    userDB.LastLogin = DateTimeOffset.Now;

                    result.Data.Add("token", token);
                    result.Data.Add("refreshToken", refreshToken);
                    result.Data.Add("expires", Constants.API_EXPIRES_MINUTE.ToString());

                    transaction = await _context.Database.BeginTransactionAsync();
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    _logger.LogInformation($"[{_className}][{method}] Login thành công");
                }

                _logger.LogInformation($"[{_className}][{method}] End");
                return result;
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> GetGoogleUserTokenAsync(string oauthCode)
        {
            ResponseInfo result = new ResponseInfo();
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                GoogleAuthorizationCodeFlow flow = new GoogleAuthorizationCodeFlow(
                new GoogleAuthorizationCodeFlow.Initializer
                {
                    ClientSecrets = new ClientSecrets()
                    {
                        ClientId = _googleOAuthSettings.ClientId,
                        ClientSecret = _googleOAuthSettings.ClientSecret
                    },
                });
                var token = await flow.ExchangeCodeForTokenAsync(string.Empty, oauthCode, _googleOAuthSettings.RedirectUri, CancellationToken.None);
                GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(token.IdToken);
                UserDto googleAcc = new()
                {
                    Username = payload.Email,
                    Password = "",
                    Email = payload.Email,
                };

                var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == googleAcc.Email);
                if (user == null)
                {
                    await RegisterAccount(googleAcc);
                }
                UserLogin newAccount = new()
                {
                    Username = googleAcc.Username,
                    Password = googleAcc.Password,
                };
                result = await CheckAccount(newAccount);
                _logger.LogInformation($"[{_className}][{method}] End");
                return result;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> RefreshToken(Token token)
        {
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();

            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");

                ResponseInfo result = new ResponseInfo();
                DateTimeOffset now = DateTimeOffset.Now.AddMinutes(-5);
                var userTokenDB = _context.UserTokens.Include(x => x.User)
                    .FirstOrDefault(x => x.RefreshToken == token.RefreshToken && x.Timeout >= now);

                _logger.LogInformation($"[{_className}][{method}] Kiểm tra thông tin token cũ");

                if (userTokenDB != null)
                {
                    string newToken = Security.GenerationJWTCode(new JwtData()
                    {
                        UserId = userTokenDB.UserId,
                        Username = userTokenDB.User.Username,
                    });
                    string refreshToken = Helpers.RenderToken(userTokenDB.UserId.ToString(), 180);
                    userTokenDB.JwtToken = newToken;
                    userTokenDB.RefreshToken = refreshToken;
                    userTokenDB.Timeout = DateTimeOffset.Now.AddMinutes(Constants.API_EXPIRES_MINUTE);
                    userTokenDB.User.LastLogin = now;
                    result.Data.Add("token", newToken);
                    result.Data.Add("refreshToken", refreshToken);
                    result.Data.Add("expires", (Constants.API_EXPIRES_MINUTE * 60).ToString());
                    transaction = await _context.Database.BeginTransactionAsync();
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                else
                {
                    return null;
                }

                _logger.LogInformation($"[{_className}][{method}] End");

                return result;
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> RegisterAccount(UserDto user)
        {
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");

                ResponseInfo result = new ResponseInfo();

                if (result.Code != CodeResponse.OK)
                {
                return result;
                }

                var existUser = await _context.Users
                    .FirstOrDefaultAsync(x => x.Username == user.Username || x.Email == user.Username);

                _logger.LogInformation($"[{_className}][{method}] Kiểm tra thông tin người dùng nhập");

                if (existUser != null)
                {
                    result.MsgNo = "Exist UserName";
                    result.Code = CodeResponse.BAD_REQUEST;
                    return result;
                }

                // Tạo token và lưu các thông tin cần thiết khi login
                _logger.LogInformation($"[{_className}][{method}] Tạo token cho trang TRN");

                string str = Helpers.RenderToken("", 20);
                UserTbl newUser = new UserTbl()
                {
                    Username = user.Username,
                    Password = Security.GetSHA256(Security.GetMD5(user.Password)),
                    Email = user.Email,
                    Phone = user.Phone,
                };

                newUser.Roles.Add(new RolesOfUser
                {
                    RoleId = R001.User.CODE,
                });

                transaction = await _context.Database.BeginTransactionAsync();
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                _logger.LogInformation($"[{_className}][{method}] Login thành công");

                _logger.LogInformation($"[{_className}][{method}] End");
                return result;
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }

        public async Task<ResponseInfo> RemoveToken()
        {
            IDbContextTransaction transaction = null;
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                ResponseInfo result = new ResponseInfo();
                DateTimeOffset now = DateTimeOffset.Now;
                string jwtToken = _identityService.GetToken();
                IEnumerable<UserToken> userTokenDBs = _context.UserTokens.Include(x => x.User)
                    .Where(x => x.JwtToken == jwtToken);

                foreach (UserToken userTokenDB in userTokenDBs)
                {
                    userTokenDB.JwtToken = "";
                    userTokenDB.RefreshToken = "";
                    userTokenDB.User.LastLogout = now;
                }

                transaction = await _context.Database.BeginTransactionAsync();
                await _context.SaveChangesAsync();
                await transaction?.CommitAsync();
                AppState.Instance.CurrentUser = new ();
                _logger.LogInformation($"[{_className}][{method}] End");

                return result;
            }
            catch (Exception e)
            {
                await _context.RollbackAsync(transaction);
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                throw;
            }
        }
    }
}