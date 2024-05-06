using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Login.Schemas
{
    public class GoogleOAuthCode
    {
        [JsonProperty("oAuthCode")]
        public string OAuthCode { get; set; }
    }
}