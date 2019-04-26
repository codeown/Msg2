using Msg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Msg2.Controllers
{
    public class HomeController : Controller
    {
        Msg2Context db = new Msg2Context();  //Создание объекта контекста данных

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //==================================================
        [HttpGet]
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public string Send(Message message)  //В качестве принимаемого параметра указываем модель Message, объект назовем message
        {
            //From и Body подставятся из формы. MessageId генерируется автоматически БД, как первичный ключ

            message.DateTime = DateTime.Now;  //DateTime заполним текущим временем
            db.Messages.Add(message); //Добавим эти данные в БД
            db.SaveChanges(); //Сохраним изменения в БД
                        
            return $"{message.From}, Ваше соообщение отправлено";  
            
        }
        //==================================================

        public ActionResult AllMessages() //Вывод всех сообщений
        {
            IEnumerable<Message> messages = db.Messages;
            ViewBag.Messages = messages;
            return View();
        }

        public ActionResult MessagesFilter(DateTime? DateTime) //Вывод всех сообщений с фильтрацией
        {
            //IEnumerable<Message> messages = db.Messages;
            //ViewBag.Messages = messages;

            ViewBag.NameSortParm = DateTime == "Date" ? "Date desc" : "Date";
            var messgs = from DateTime in db.Messages select DateTime;
            switch (DateTime)
            {
                case "Date":
                    messgs = messgs.OrderBy(s => s.DateTime);
                    break;
                case "Date desc":
                    messgs = messgs.OrderByDescending(s => s.DateTime);
                    break;
            }

            return View(messgs.ToList());
        }

    }
}