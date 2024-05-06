using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Database.Entities
{
    [Table("users")]
    public class User : TableWithLongId
    {
        public User()
        {
            Tokens = new HashSet<UserToken>();
            Roles = new HashSet<RolesOfUser>();
            Folders = new HashSet<Folder>();
            Messages = new HashSet<Message>();
            Conversations = new HashSet<Conversation>();
            Bookmarks = new HashSet<Bookmark>();
        }

        [StringLength(50)]
        [Column("username")]
        public string Username { get; set; }

        [StringLength(100)]
        [Column("password")]
        public string Password { get; set; }

        [StringLength(255)]
        [Column("email")]
        public string? Email { get; set; }

        [StringLength(20)]
        [Column("phone")]
        public string? Phone { get; set; }

        [Column("last_login")]
        public DateTimeOffset? LastLogin { get; set; }

        [Column("last_logout")]
        public DateTimeOffset? LastLogout { get; set; }

        public virtual ICollection<UserToken> Tokens { set; get; }

        public virtual ICollection<RolesOfUser> Roles { set; get; }

        public virtual ICollection<Folder> Folders { set; get; }

        public virtual ICollection<Conversation> Conversations { set; get; }

        public virtual ICollection<Message> Messages { set; get; }
        public virtual ICollection<Bookmark> Bookmarks {get; set;}
    }
}