using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Chats.Schemas
{
    public class InputMessage
    {
        [JsonProperty("id")]
        public string Id { set; get; }

        [JsonProperty("content")]
        public string Content { set; get; }

        [JsonProperty("isMy")]
        public bool IsMy { set; get; }

        [JsonProperty("isNoted")]
        public bool IsNoted { set; get; }

        [JsonProperty("note")]
        public string? Note { set; get; }
        
        [JsonProperty("updatedAt")]
        public DateTimeOffset? UpdatedAt { set; get; }
    }
}