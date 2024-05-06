using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookmarkWeb.API.Database.Entities
{
    [Table("api_keys")]
    public class ApiKey : TableWithLongId
    {
        [Required]
        [StringLength(100)]
        [Column("key")]
        public string Key { set; get; }

        [StringLength(200)]
        [Column("description")]
        public string Description { set; get; }

        [Column("from")]
        public DateTimeOffset? From { set; get; }

        [Column("to")]
        public DateTimeOffset? To { set; get; }
    }
}