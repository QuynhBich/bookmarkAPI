using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Chats.Schemas
{
    public class InputUser
    {
        [JsonProperty("username")]
        public string Username { set; get; }
    }
}