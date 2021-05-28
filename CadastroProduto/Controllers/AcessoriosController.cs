using System;
using System.Collections.Generic;
using System.Diagnostics;
using CadastroProduto.Data;
using CadastroProduto.Fachada;
using CadastroProduto.Models.Domain;
using CadastroProduto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.Controllers
{
    public class AcessoriosController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly Facade facade;

        public AcessoriosController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            facade = new Facade(dbContext);            
        }

        public IActionResult Index()
        {
            Acessorio acessorio = new Acessorio();           

            List<Acessorio> resultado = new List<Acessorio>();
            foreach (EntidadeDominio x in facade.Consultar(acessorio))
            {
                resultado.Add((Acessorio)x);
            }
            return View(resultado);
        }

        public IActionResult Create(Linha linha)
        {
            List<Linha> resultado = new List<Linha>();            
            foreach (EntidadeDominio x in facade.Consultar(linha))
            {
                resultado.Add((Linha)x);
            }
            
            var viewModel = new AcessorioBasicoFormViewModel { Linhas = resultado };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Acessorio acessorio)
        {         
          var conf = facade.Cadastrar(acessorio);

            if (conf != null)
            {
                return RedirectToAction(nameof(Error), new { message = conf });
            }

            return RedirectToAction("Create", "Acessorios", acessorio.Linha);          
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }   
                        
            var obj = facade.ConsultarId(new Acessorio(), id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Acessório não encontrado" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {            
            var obj = facade.ConsultarId(new Acessorio(), id);
            facade.Excluir(obj);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            
            var obj = facade.ConsultarId(new Acessorio(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Acessório não encontrado" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {             
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
           
            var obj = (Acessorio)facade.ConsultarId(new Acessorio(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Acessório não encontrado" });
            }            
            
            List<Linha> resultado = new List<Linha>();
            
            foreach (EntidadeDominio x in facade.Consultar(obj.Linha))
            {
                resultado.Add((Linha)x);
            }

            var viewModel = new AcessorioBasicoFormViewModel { Acessorio = obj, Linhas = resultado };

            return View(viewModel);             
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Acessorio acessorio)
        {
            if (id != acessorio.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Acessório escolhido para cadastrar diferente do cadastrado" });
            }

            try
            {                
                facade.Alterar(acessorio);
                return RedirectToAction("Index");
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }           
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sair()
        {
           return RedirectToAction("Index", "Produtos");
        }      


        public IActionResult CreateLinha()
        {
            return RedirectToAction("Create", "Linhas");
        }

        public IActionResult Error(String message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
