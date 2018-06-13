using System;

namespace ContactsApp
{
    [Serializable]
    public class Message
    {
        public string Sender { get; set; }
        public string Msg { get; set; }
        public DateTime date { get; set; }

        public Message(string sender, string msg, DateTime dt)
        {
            this.Sender = sender;
            this.Msg = msg;
            date = dt;
        }

        public override string ToString()
        {
            return Sender;
        }

        public string MessageToString()
        {
            return Msg;
        }

        public string DateToString()
        {
            return date.ToString();
        }
    }
}