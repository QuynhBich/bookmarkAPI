using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Database.Entities
{
    public class RolesOfUser: Table
    {
        public RolesOfUser()
        {
            ForceDel = true;
        }

        [Key]
        [Column("user_id", Order = 1)]
        public long UserId { set; get; }

        [Key]
        [Column("role_id", Order = 2)]
        [StringLength(21)]
        public string RoleId { set; get; }

        public virtual User User { set; get; }

        public virtual Role Role { set; get; }
    }
}