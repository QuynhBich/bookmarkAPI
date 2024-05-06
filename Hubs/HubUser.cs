using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Hubs
{
    public class HubUser
    {
        public HubUser()
        {
            Conventions = new HashSet<GptConvention>();
        }

        public string Username { set; get; }

        public HashSet<string> ConnectionIds { get; set; }

        public HashSet<GptConvention> Conventions { set; get; }
    }
}