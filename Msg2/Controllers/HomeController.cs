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
        Msg2Context db = new Msg2Context();

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

        [HttpGet]
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        public string Send(Message message)
        {
            message.DateTime = DateTime.Now;
            db.Messages.Add(message);
            db.SaveChanges();

            return "Соообщение отправлено";
        }

    }
}