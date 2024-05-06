using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database.Entities
{
    public class Bookmark: Table
    {
        public Bookmark()
        {
            ForceDel = true;
        }
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        [Comment("Primary key")]
        [Column("id", Order = 1)]
        public Guid Id { set; get; }

        [Column("conversation_id")]
        public Guid? ConversationId { set; get; }
        [Column("folder_id")]
        public Guid? FolderId { set; get; }

        [Column("user_id")]
        public long? UserId { set; get; }

        [Required]
        [Column("url")]
        public string? Url { set; get; }

        [Required]
        [Column("domain")]
        public string? Domain { set; get; }

        [StringLength(100)]
        [Column("description")]
        public string? Description { set; get; }

        [StringLength(100)]
        [Column("note")]
        public string? Note { set; get; }

        [StringLength(512)]
        [Column("image")]
        public string? Image { set; get; }

        [StringLength(100)]
        [Column("title")]
        public string? Title { set; get; }

        public virtual Conversation Conversation { set; get; }
        public virtual User User {set; get;}
        public virtual Folder Folder { set; get; }
    }
}