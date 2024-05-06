using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Models.Login.Schemas
{
    public class GoogleOAuthSettings
    {
        public string? ClientId { get; set; }

        public string? ClientSecret { get; set; }

        public string? RedirectUri { get; set; }
    }
}