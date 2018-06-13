using System;

namespace ContactsApp
{
    [Serializable]
    public class Message
    {
        public string Sender { get; set; }
        public string Msg { get; set; }
        public string Date { get; set; }

        public Message(string sender, string msg, string date)
        {
            this.Sender = sender;
            this.Msg = msg;
            Date = date;
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
            return Date;
        }
    }
}