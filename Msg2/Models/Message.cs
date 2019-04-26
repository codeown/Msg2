using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Msg2.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public DateTime DateTime { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
    }

    public class MessageListViewModel
    {
        public IEnumerable<Message> Messages { get; set; } //Хранит те сообщения, которые были отфильтрованы
        public SelectList MessageId { get; set; } //Хранит критерий фильтрации "По убыванию", "По возрастанию"
    }
}