using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Chats.Schemas
{
    public class InputBookmark
    {
        [JsonProperty("bookmarkId")]
        public string BookmarkId { set; get; }
        [JsonProperty("bookmarkUrl")]
        public string BookmarkUrl { set; get; }
    }
}