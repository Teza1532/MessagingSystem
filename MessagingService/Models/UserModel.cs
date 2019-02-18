using System;

namespace MessagingService.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public DateTime Sent { get; set; }
        public string UserName { get; set; }

        public String SentFormatted()
        {
            var sent = this.Sent;
            var now = DateTime.Now;
            double timeDiff = (now - sent).Minutes;

            if (timeDiff < 60)
            {
                return "Sent " + timeDiff.ToString() + " Minutes ago";
            }
            else
            {
                return "Sent " + (Math.Floor(timeDiff / 60)).ToString() + " hours and " + (timeDiff - (Math.Floor(timeDiff / 60))).ToString() + "minutes ago";
            }
        }

    }
}
