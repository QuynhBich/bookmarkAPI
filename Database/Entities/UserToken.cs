using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookmarkWeb.API.Database.Entities
{
    [Table("user_tokens")]
    public partial class UserToken : TableWithLongId
    {
        public UserToken()
        {
            ForceDel = true;
        }

        [Column("user_id")]
        public long UserId { set; get; }

        [StringLength(500)]
        [Column("jwt_token")]
        public string JwtToken { set; get; }

        [StringLength(500)]
        [Column("refresh_token")]
        public string RefreshToken { set; get; }

        [StringLength(500)]
        [Column("validate_token")]
        public string ValidateToken { set; get; }

        [Column("timeout")]
        public DateTimeOffset? Timeout { set; get; }

        public virtual User User { set; get; }
    }
}