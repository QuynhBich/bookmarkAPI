using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Models.Common.Schemas
{
    public class User
    {
        public long Id { get; set; }

        public string Username { get; set; }

        public string? Email { get; set; }

        public string RoleId { set; get; }
    }
}