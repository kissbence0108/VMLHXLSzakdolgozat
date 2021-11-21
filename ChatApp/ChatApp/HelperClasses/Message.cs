using System;

namespace ChatApp.HelperClasses
{
   public class Message
    {

        public Message(string Username, string MessageText, DateTime? SentTime)
        {
            this.Username = Username;
            this.MessageText = MessageText;
            this.SentTime = SentTime;
        }

        public string Username { get; set; }
        public string MessageText { get; set; }
        public DateTime? SentTime { get; set; }
    }
}
