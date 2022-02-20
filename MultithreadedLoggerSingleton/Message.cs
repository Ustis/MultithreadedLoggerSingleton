using System;

namespace MultithreadedLoggerSingleton
{
    public class Message
    {
        private MessageType messageType;
        private String source;
        private DateTime dateTime;
        private String content;

        public Message(MessageType messageType, String source, String content)
        {
            this.messageType = messageType;
            this.source = source;
            this.content = content;
        }

        public Message(MessageType messageType, String source, DateTime dateTime, String content)
        {
            this.messageType = messageType;
            this.source = source;
            this.dateTime = dateTime;
            this.content = content;
        }

        public String toXML()
        {
            return string.Format(
                "<message>\n" +
                "\t<messageType>{0}</messageType>\n" +
                "\t<source>{1}</source>\n" +
                "\t<dateTime>{2}</dateTime>\n" +
                "\t<content>{3}</content>\n" +
                "</message>\n",
                messageType.ToString(), source, dateTime.ToString(), content);
        }

        public override String ToString()
        {
            return messageType.ToString() + "\t" + source + "\t" + dateTime.ToString() + "\t" + content + "\n";
        }
    }
}