using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelaWEB.Models;



namespace TelaWEB.Controllers
{
    public class CelularController : Controller
    {
        // GET: Celular

        BDTCCEntities bd = new BDTCCEntities();
        
        public ActionResult CadastroCelular()
        {
            return View();
        }

        
        public ActionResult ListaCelular()
        {          
            return View(bd.Celular.ToList());
        }


    }
}