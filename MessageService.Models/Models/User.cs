using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MessageService.Models.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
