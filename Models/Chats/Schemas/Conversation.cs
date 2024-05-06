using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookmarkWeb.API.Models.Chats.Schemas
{
    public class Conversation
    {
        [JsonProperty("conversationId")]
        public string ConversationId { set; get; }
        [JsonProperty("bookmark")]
        public InputBookmark Bookmark { set; get; }

        [JsonProperty("message")]
        public InputMessage Message { set; get; }

        [JsonProperty("reply")]
        public InputMessage Reply { set; get; }

        [JsonProperty("user")]
        public InputUser User { set; get; }

        [JsonProperty("name")]
        public string Name { set; get; }
        [JsonProperty("isExpanded")]
        public bool IsExpanded { set; get; }
    }
}