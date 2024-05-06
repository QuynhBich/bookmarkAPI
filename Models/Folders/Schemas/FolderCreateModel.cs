using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Folders.Schemas
{
    public class FolderCreateModel
    {
        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("description")]
        public string? Description { set; get; }
    }
}