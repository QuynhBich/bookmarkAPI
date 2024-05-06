using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database.Entities
{
    [Table("folders")]
    public class Folder : Table
    {

        public Folder()
        {
            Bookmarks = new HashSet<Bookmark>();
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
        
        [Required]
        [StringLength(50)]
        [Column("name")]
        public string Name { set; get; }

        [StringLength(100)]
        [Column("description")]
        public string? Description { set; get; }

        public virtual ICollection<Bookmark> Bookmarks { set; get; }
        public virtual User User { set; get; }
    }
}