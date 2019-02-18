using MessageService.Models.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MessageService.Models.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageID { get; set; }
        public string Content { get; set; }
        public DateTime Sent { get; set; }
        public bool Deleted { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual User SentBy { get; set; }
        public virtual User SentTo { get; set; }
    }
}
