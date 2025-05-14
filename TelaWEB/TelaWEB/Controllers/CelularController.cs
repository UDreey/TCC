using System;
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

       // bdReciclaEntities2 bd = new bdReciclaEntities2();
        
        public ActionResult CadastroCelular()
        {
            return View();
        }


        public ActionResult CadastrarCelular(int idPessoa, string modelo, string marca, string estadoFisico)
        {
            Celular cl = new Celular();
            cl.idPessoa = idPessoa;
            cl.marca = marca;
            cl.modelo = modelo;

            return View();
        }
    }
}