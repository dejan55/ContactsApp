using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    [Serializable]
    public class Message
    {
        public String sender { get; set; }
        public String msg { get; set; }

        public Message(String sender, String msg)
        {
            this.sender = sender;
            this.msg = msg;
        }
        
        public String ToString()
        {
            return sender;
        }

        public String MessageToString()
        {
            return msg;
        }
    }
}
