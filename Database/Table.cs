using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database
{
    public class Table
    {
        /// <summary>
        /// Data creation time
        /// </summary>
        [Comment("Data creation time")]
        [Column("created_at")]
        public DateTimeOffset CreatedAt { set; get; }
        /// <summary>
        /// Data creator id
        /// </summary>
        [Comment("Data creator id")]
        [Column("created_by")]
        public long CreatedBy { set; get; }
        /// <summary>
        /// Data updated time
        /// </summary>
        [Comment("Data updated time")]
        [Column("updated_at")]
        public DateTimeOffset? UpdatedAt { set; get; }
        /// <summary>
        /// Data updater id
        /// </summary>
        [Comment("Data updater id")]
        [Column("updated_by")]
        public long? UpdatedBy { set; get; }
        /// <summary>
        /// Data deleted time
        /// </summary>
        [Comment("Data deleted time")]
        [Column("deleted_at")]
        public DateTimeOffset? DeletedAt { set; get; }
        /// <summary>
        /// Data deleter id
        /// </summary>
        [Comment("Data deleter id")]
        [Column("deleted_by")]
        public long? DeletedBy { set; get; }
        /// <summary>
        /// Flag check deleted data
        /// </summary>
        [Comment("Flag check deleted data")]
        [Column("del_flag")]
        public bool DelFlag { set; get; }
        /// <summary>
        /// Physically erase data
        /// </summary>
        [NotMapped]
        public bool ForceDel { set; get; } = false;
    }
}