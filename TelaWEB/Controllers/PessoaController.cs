using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelaWEB.Models;

namespace TelaWEB.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Pessoa
        BDTCCEntities bd = new BDTCCEntities();

        public ActionResult CadastroPessoa()
        {
            return View();
        }


        [HttpGet]
        public ActionResult CadPessoaFisica()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadPessoaFisica(string email, string senha, string nome, string telefone, string tipoPessoa, long cpf, string sexo, DateTime dataNascimento, string NumeroCasa, long cep, string bairro, string rua, string cidade, string estado)
        {
            Pessoa p = new Pessoa();

            p.email = email;
            p.senha = senha;
            p.nome = nome;
            p.telefone = telefone;
            p.tipoPessoa = "F";

            bd.Pessoa.Add(p);
            bd.SaveChanges();


            this.cadEndereco(p.idPessoa, cep, bairro, rua, estado, cidade);
            this.CadastroPessoaFisica(p.idPessoa, cpf, sexo, dataNascimento, NumeroCasa);



            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult cadEndereco(int idPessoa, long cep, string bairro, string rua, string estado, string cidade)
        {

            Endereco en = new Endereco();
            en.idPessoa = idPessoa;
            en.cep = cep;
            en.bairro = bairro;
            en.rua = rua;
            en.estado = estado;
            en.cidade = cidade;

            bd.Endereco.Add(en);
            bd.SaveChanges();

            return View();
        }

        [HttpPost]
        public ActionResult CadastroPessoaFisica(int idPessoa, long cpf, string sexo, DateTime dataNascimento, string NumeroCasa)
        {
            PessoaFisica pf = new PessoaFisica();
            pf.idPessoa = idPessoa;
            pf.cpf = cpf;
            pf.sexo = sexo;
            pf.dataNascimento = dataNascimento;
            pf.numeroCasa = NumeroCasa;

            bd.PessoaFisica.Add(pf);
            bd.SaveChanges();

            return View();

        }

        [HttpGet]
        public ActionResult CadastroPessoaFisica()
        {

            return View();

        }

        [HttpGet]
        public ActionResult cadEndereco()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CadPessoaJuridica(string email, string senha, string nome, string telefone, string tipoPessoa, string nomeEmpresa, string cnpj)
        {

            Pessoa p = new Pessoa();
            p.email = email;
            p.nome = nome;
            p.senha = senha;
            p.telefone = telefone;
            p.tipoPessoa = "J";

            bd.Pessoa.Add(p);
            bd.SaveChanges();


            this.CadastroPessoaJuridica(p.idPessoa, nomeEmpresa, cnpj);
            return RedirectToAction("CadPessoaJuridica", "Pessoa");

        }

        [HttpPost]
        public ActionResult CadastroPessoaJuridica(int idPessoa, string nomeEmpresa, string cnpj)
        {
            PessoaJuridica pj = new PessoaJuridica();
            pj.idPessoa = idPessoa;
            pj.nomeEmpresa = nomeEmpresa;
            pj.cnpj = cnpj;

            bd.PessoaJuridica.Add(pj);
            bd.SaveChanges();

            return View();
        }



        [HttpGet]
        public ActionResult CadPessoaJuridica()
        {
            return View();


        }

        [HttpGet]
        public ActionResult CadastroPessoaJuridica()
        {

            return View();
        }


        [HttpGet]
        public ActionResult LoginPessoa()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginPessoa(string email, string senha)
        {

            foreach (var item in bd.Pessoa.ToList())
            {
                if ((item.email == email) && (item.senha == senha) && (item.tipoPessoa == "F"))
                {
                    Pessoa p = new Pessoa();
                    p = item;
                    Session["LoginAcesso"] = p;
                    return RedirectToAction("DashbordFisico", "Home");

                }
                else if ((item.email == email) && (item.senha == senha) && (item.tipoPessoa == "J"))
                {
                    Pessoa p = new Pessoa();
                    p = item;
                    Session["LoginAcesso"] = p;
                    return RedirectToAction("DashbordJuridico", "Home");

                }


            }
            return View();



        }

        public ActionResult Sair()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult CadastrarCelular()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CadastrarCelular(string marca, string modelo, string estadoFisico)
        {

            if (Session["LoginAcesso"] != null)
            {
                Pessoa p = (Pessoa)Session["LoginAcesso"];
                Celular cl = new Celular();
                cl.idPessoa = p.idPessoa;
                cl.marca = marca;
                cl.modelo = modelo;
                cl.estadoFisico = estadoFisico;

                bd.Celular.Add(cl);
                bd.SaveChanges();

                return RedirectToAction("DashbordFisico", "Home");
            }

            return View();
            
        }


        public ActionResult ListaCelular()
        {
            return View(bd.Celular.ToList());
        }

    }




}