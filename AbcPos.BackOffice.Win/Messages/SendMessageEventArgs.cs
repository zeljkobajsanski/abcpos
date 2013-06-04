using System;

namespace AbcPos.BackOffice.Win.Messages
{
    public class SendMessageEventArgs : EventArgs
    {
        public Message Message { get; set; }

        public bool Confirmed { get; set; }

        public SendMessageEventArgs(Message message)
        {
            Message = message;
        }
    }
}