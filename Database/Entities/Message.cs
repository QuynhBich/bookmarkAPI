using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookmarkWeb.API.Database.Entities
{
    [Table("messages")]
    public class Message : Table
    {
        public Message()
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
        public Guid ConversationId { set; get; }

        [Column("user_id")]
        public long? UserId { set; get; }

        [Column("content")]
        public string Content { set; get; }

        [Column("note")]
        public string? Note { set; get; }

        [Column("isNoted")]
        public bool IsNoted { set; get; }

        public virtual Conversation Conversation { set; get; }

        public virtual User User { set; get; }
    }
}