using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Commons
{
    public class Constants
    {
        public static readonly string JWT_SECRET_KEY = "23wsQUsX8rZNgN6xcvNYW4UagZWDAWgruueUzS4nGy9EKh";

        public static readonly string JWT_ISSUER = "https://bookmark.com/";

        public static readonly string JWT_AUD = "Bookmark";

        public static readonly int API_EXPIRES_MINUTE = 43200;
        
        public static readonly string CorsPolicy = "CorsPolicy";
    }
}