using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Msg2.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime DateTime { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
    }
}