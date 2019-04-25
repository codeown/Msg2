using Msg2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

    }
}