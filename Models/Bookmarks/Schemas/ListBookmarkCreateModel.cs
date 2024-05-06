using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Bookmarks.Schemas
{
    public class ListBookmarkCreateModel
    {
        public ListBookmarkCreateModel()
        {
            List = new List<BookmarkCreateModel>();
        }
        [JsonProperty("list")]
        public List<BookmarkCreateModel> List { get; set; }
    }
}