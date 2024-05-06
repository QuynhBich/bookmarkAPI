using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database
{
    public class TableWithLongId: Table
    {
        /// <summary>
        /// Primary key auto-increment
        /// </summary>
        [Key]
        [Comment("Primary key auto-increment")]
        [Column("id", Order = 1)]
        public long Id { set; get; }
    }
}