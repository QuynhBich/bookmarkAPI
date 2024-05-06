using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Database.Entities
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<RolesOfUser>();
        }

        [Key]
        [StringLength(21)]
        [Column("id")]
        public string Id { set; get; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { set; get; }

        [StringLength(200)]
        [Column("description")]
        public string Description { set; get; }

        public virtual ICollection<RolesOfUser> Users { set; get; }
    }
}