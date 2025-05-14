using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelaWEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
       
            return View();
        }

        public ActionResult DashbordFisico()
        {
          
            return View();
        }

        public ActionResult DashbordJuridica()
        {

            return View();
        }
    }
}