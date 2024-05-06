using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Bookmarks.Schemas
{
    public class BookmarkCreateModel
    {
        [JsonProperty("folderId")]
        public Guid? FolderId { set; get; }
        [JsonProperty("url")]
        public string? Url { set; get; }
        [JsonProperty("domain")]
        public string? Domain { set; get; }
        [JsonProperty("description")]
        public string? Description { set; get; }
        [JsonProperty("note")]
        public string? Note { set; get; }
        [JsonProperty("image")]
        public string? Image { set; get; }
        [JsonProperty("title")]
        public string? Title { set; get; }
    }
}