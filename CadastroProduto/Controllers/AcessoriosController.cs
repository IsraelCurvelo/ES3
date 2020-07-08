using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Facade;
using CadastroProduto.Models.Domain;
using CadastroProduto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CadastroProduto.Controllers
{
    public class AcessoriosController : Controller
    {
        private readonly DataBaseContext dbContext;        
        
        public AcessoriosController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;          
        }

        public IActionResult Index()
        {
            Acessorio acessorio = new Acessorio();
            AcessorioFacade abf = new AcessorioFacade(dbContext);

            List<Acessorio> resultado = new List<Acessorio>();
            foreach (EntidadeDominio x in abf.Consultar(acessorio))
            {
                resultado.Add((Acessorio)x);
            }
            return View(resultado);
        }

        public IActionResult Create(Linha linha)
        {
            
            LinhaFacade lf = new LinhaFacade(dbContext);           
            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in lf.Consultar(linha))
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
            
            AcessorioFacade cf = new AcessorioFacade(dbContext);                  
            var conf = cf.Cadastrar(acessorio);


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
            AcessorioFacade facade = new AcessorioFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
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
            AcessorioFacade facade = new AcessorioFacade(dbContext);
            var obj = facade.ConsultarId(id);
            facade.Excluir(obj);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            AcessorioFacade facade = new AcessorioFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
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

            AcessorioFacade facade = new AcessorioFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Acessório não encontrado" });
            }
            
            LinhaFacade lf = new LinhaFacade(dbContext);
            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in lf.Consultar(obj.Linha))
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
                AcessorioFacade facade = new AcessorioFacade(dbContext);
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
