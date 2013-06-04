namespace AbcPos.BackOffice.Win.Messages
{
    public class Message
    {
        public MessageType MessageType { get; set; }

        public string MessageText { get; set; }

        public Message(MessageType messageType, string messageText)
        {
            MessageType = messageType;
            MessageText = messageText;
        }
    }

    public class MessageSaved : Message
    {
        public MessageSaved() : base(MessageType.Info, "Podaci su uspešno sačuvani"){}
    }

    public enum MessageType
    {
        Info,
        Wraning,
        Error,
        Question
    }
}