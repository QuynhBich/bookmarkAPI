using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Commons.Schemas
{
    public class JwtData
    {
        public long UserId { set; get; }
        public string Username { set; get; }
        public string Aud { set; get; }
        public string Iss { set; get; }
        public string Secret { set; get; }
    }
}