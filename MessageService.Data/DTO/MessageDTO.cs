using System;

namespace MessageService.Data.DTO
{
    public class MessageDTO
    {
        public int MessageID { get; set; }
        public int SentByID { get; set; }
        public string Content { get; set; }
        public DateTime Sent { get; set; }
        public int SentToID { get; set; }
    }

    public class UserContactsDTO {
        public string Name { get; set; }
        public int ContactID { get; set; }
        public DateTime Sent { get; set; }
    }
}
