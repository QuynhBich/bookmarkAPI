using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookmarkWeb.API.Database.Entities
{
    [Table("call_api_logs")]
    public class CallApiLog : Table
    {
        [Key]
        [Column("id", Order = 1)]
        public Guid Id { set; get; }

        [StringLength(255)]
        [Column("url")]
        public string Url { set; get; }

        [Column("query_string")]
        public string QueryString { set; get; }

        [Column("body")]
        public string Body { set; get; }

        [Column("response")]
        public string Response { set; get; }

        [StringLength(255)]
        [Column("class")]
        public string Class { set; get; }

        [StringLength(255)]
        [Column("method")]
        public string Method { set; get; }

        [StringLength(10)]
        [Column("api_method")]
        public string ApiMethod { set; get; }

        [StringLength(50)]
        [Column("status")]
        public string Status { set; get; }

        [Column("is_call_out")]
        public bool IsCallOut { set; get; }

        [Column("count_recall")]
        public int CountRecall { set; get; }

        [Column("recalling")]
        public bool Recalling { set; get; }
    }
}