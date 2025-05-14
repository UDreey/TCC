using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelaWEB.Models;

namespace TelaWEB.Controllers
{
    public class PropostaController : Controller
    {
        // GET: Proposta

        
         static int idCelular = 0;

        BDTCCEntities bd = new BDTCCEntities();

        /*public ActionResult TelaPropostaFisica()
        {
            foreach (var item in bd.Proposta.ToList())
            {

                Pessoa p = (Pessoa)Session["LoginAcesso"];
                Proposta po = bd.Proposta.ToList().Find(x => x. == p.id);
            }

            return View()



        }*/

        [HttpPost]
        public ActionResult CadastroProposta(decimal valor, DateTime date, string horario)
        {
            if (Session["LoginAcesso"] != null)
            {

                Pessoa p = (Pessoa)Session["LoginAcesso"];
                Proposta po = new Proposta();  


                po.idPessoaJuridica = p.idPessoa;
                //po.idCelular = id;
                po.idCelular = idCelular;
                po.horario = horario;
                po.data = date;
                po.valor = valor;
                po.status = "EAprova";

                bd.Proposta.Add(po);
                bd.SaveChanges();

                return RedirectToAction("DashbordJuridico", "Home");

            }

            return View();
        }

        [HttpGet]
        public ActionResult CadastroProposta(int id)
        {
            idCelular = id;
            
            return View();
        }

        public ActionResult TelaPropostaFisica(){

            Pessoa p = (Pessoa)Session["LoginAcesso"];
            Proposta po = new Proposta();

            List<Celular> celulares = new List<Celular>();

            foreach (var item in bd.Celular.ToList())
            {
                if ((item.idPessoa == p.idPessoa) && (item.idCelular == po.idCelular))
                {
                    celulares.Add(item);
                    return View(celulares);
                }
                 

            }
            return View();

        }


        public ActionResult TelaPropostaJuridica()
        {
            Pessoa p = (Pessoa)Session["LoginAcesso"];

                List<Proposta> Proposta = new List<Proposta>();

                foreach (var item in bd.Proposta.ToList())
                {

                    if ((item.idPessoaJuridica == p.idPessoa))
                    {
   
                            Proposta.Add(item);
                                           

                        return View(Proposta.ToList());
                    }
                    /*else
                    {
                        return RedirectToAction("DashbordJuridico", "Home");
                    }*/

                }

            return View();

        }



    }
}