using System.Runtime.CompilerServices;
using System.Web;
using BookmarkWeb.API.Commons;
using BookmarkWeb.API.Database;
using BookmarkWeb.API.Database.Entities;
using BookmarkWeb.API.Models.Common.Schemas;
using BookmarkWeb.API.Models.Login;
using BookmarkWeb.API.Models.Login.Schemas;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookmarkWeb.API.Services
{
    public interface IIdentityService
    {
        string GetToken();
        long GetUserId();
    }
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ILogger<IdentityService> _logger;
        private readonly string _className = "";
        private readonly DataContext _context;

        public IdentityService(
            IConfiguration configuration,
            IHttpContextAccessor httpContext,
            ILogger<IdentityService> logger,
            DataContext context
        )
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _httpContext = httpContext ?? throw new ArgumentNullException(nameof(httpContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _className = GetType().Name;
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        static string GetActualAsyncMethodName([CallerMemberName] string name = null) => name;

        public string GetToken()
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                string accessToken = _httpContext.HttpContext.Request.Headers["Authorization"];
                if (!String.IsNullOrEmpty(accessToken))
                {
                    accessToken = accessToken.Replace("Bearer", "").Trim();
                }
                else
                {
                    accessToken = _httpContext.HttpContext.Request.Cookies["token"];
                    if (!String.IsNullOrEmpty(accessToken))
                    {
                        accessToken = Security.Base64Decode(HttpUtility.UrlDecode(accessToken));
                    }
                }
                _logger.LogInformation($"[{_className}][{method}] End");
                return accessToken;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                return "";
            }
        }

        public long GetUserId()
        {
            string method = GetActualAsyncMethodName();
            try
            {
                _logger.LogInformation($"[{_className}][{method}] Start");
                long accountId = 0;
                string accessToken = GetToken();
                if (!String.IsNullOrEmpty(accessToken))
                {
                    _logger.LogInformation($"[{_className}][{method}] Get from token");
                    DateTimeOffset now = DateTimeOffset.Now;
                    UserToken userToken = _context.UserTokens.FirstOrDefault(x => x.JwtToken == accessToken && x.Timeout >= now);
                    if (userToken != null)
                    {
                        accountId = userToken.UserId;
                    }
                }
                _logger.LogInformation($"[{_className}][{method}] End");
                return accountId;
            }
            catch (Exception e)
            {
                _logger.LogError($"[{_className}][{method}] Exception: {e.Message}");
                return 0;
            }
        }
    }
}