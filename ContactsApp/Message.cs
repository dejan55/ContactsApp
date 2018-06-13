using System;

namespace ContactsApp
{
    [Serializable]
    public class Message
    {
        public string Sender { get; set; }
        public string Msg { get; set; }

        public Message(string sender, string msg)
        {
            this.Sender = sender;
            this.Msg = msg;
        }

        public override string ToString()
        {
            return Sender;
        }

        public string MessageToString()
        {
            return Msg;
        }
    }
}