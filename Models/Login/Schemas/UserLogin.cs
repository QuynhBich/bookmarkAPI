using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Login.Schemas
{
    public class UserLogin
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string? Password { get; set; }
    }
}