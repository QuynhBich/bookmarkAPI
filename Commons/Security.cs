using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BookmarkWeb.API.Commons.Schemas;
using BookmarkWeb.API.Models.Common.Schemas;
using Microsoft.IdentityModel.Tokens;

namespace BookmarkWeb.API.Commons
{
    public class Security
    {
        public static string GetSHA256(string str, string firstStr = "", string lastStr = "")
        {
            str = firstStr + str + lastStr;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(str));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string GetMD5(string str, string firstStr = "", string lastStr = "")
        {
            str = firstStr + str + lastStr;
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(str);
            MD5 my_md5 = MD5.Create();
            mang = my_md5.ComputeHash(mang);
            foreach (byte b in mang)
            {
                str_md5 += b.ToString("x2");
            }
            return str_md5;
        }

        public static string GetSimpleMD5(string str)
        {
            string str_md5 = "";
            byte[] mang = System.Text.Encoding.UTF8.GetBytes(str);
            MD5 my_md5 = MD5.Create();
            mang = my_md5.ComputeHash(mang);
            foreach (byte b in mang)
            {
                str_md5 += b.ToString("x2");
            }
            return str_md5;
        }

        public static string Base64Encode(string plainText)
        {
            try
            {
                if (String.IsNullOrEmpty(plainText))
                {
                    return "";
                }
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                string base64Str = Convert.ToBase64String(plainTextBytes);
                int endPos = 0;
                for (endPos = base64Str.Length; endPos > 0; endPos--)
                {
                    if (base64Str[endPos - 1] != '=')
                    {
                        break;
                    }
                }
                int numberPaddingChars = base64Str.Length - endPos;
                base64Str = base64Str.Replace("+", "-");
                base64Str = base64Str.Replace("/", "_");
                base64Str = base64Str.Substring(0, endPos);
                base64Str = $"{base64Str}{numberPaddingChars}";
                return base64Str;
            }
            catch
            {
                return plainText;
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            try
            {
                if (String.IsNullOrEmpty(base64EncodedData))
                {
                    return "";
                }
                base64EncodedData = base64EncodedData.Replace("-", "+");
                base64EncodedData = base64EncodedData.Replace("_", "/");
                int numberPaddingChars = 0;
                try
                {
                    numberPaddingChars = Convert.ToInt32(base64EncodedData.Substring(base64EncodedData.Length - 1, 1));
                }
                catch { }
                base64EncodedData = base64EncodedData.Substring(0, base64EncodedData.Length - 1);
                for (int i = 0; i < numberPaddingChars; i++)
                {
                    base64EncodedData += "=";
                }
                var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch
            {
                return base64EncodedData;
            }
        }

        public static string GenerationJWTCode(JwtData data)
        {
            var now = DateTime.Now;
            var configuration = AppState.Instance.Configuration.GetSection("TokenKey");
            var claims = new Claim[] {
                new("UserId", data.UserId.ToString()),
                new("Username", data.Username),
                new(JwtRegisteredClaimNames.Sub, data.Username),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid ().ToString ()),
                new(JwtRegisteredClaimNames.Iat, now.ToUniversalTime ().ToString (), ClaimValueTypes.Integer64)
            };

            var symmetricKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.Value));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha512Signature)
            };
            
            var tokenHandler= new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}