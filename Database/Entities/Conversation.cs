using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database.Entities
{
    public class Conversation: Table
    {

        public Conversation()
        {
            Messages = new HashSet<Message>();
            ForceDel = true;
        }
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [Comment("Primary key")]
        [Column("id", Order = 1)]
        public Guid Id { set; get; }

        [Column("user_id")]
        public long? UserId { set; get; }

        [Column("bookmark_id")]
        public Guid? BookmarkId { set; get; }

        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { set; get; }

        [StringLength(100)]
        [Column("description")]
        public string Description { set; get; }
        public virtual Bookmark Bookmark { set; get; }
        public virtual ICollection<Message> Messages { set; get; }
        public virtual User User { set; get; }
    }
}