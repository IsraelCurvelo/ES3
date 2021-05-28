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
    public class ProdutosController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly Facade facade;

        public ProdutosController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            facade = new Facade(dbContext);
        }

        public IActionResult Index(Produto produtos)
        {            
            Produto produto = new Produto();          

            List<Produto> resultado = new List<Produto>();
            foreach (EntidadeDominio x in facade.Consultar(produto))
            {
                resultado.Add((Produto)x);
            }
            return View(resultado);         
        }

        public IActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {                    
            var conf = facade.Cadastrar(produto);
            
            if (conf != null)
            {
                return RedirectToAction(nameof(Error), new { message = conf });
            }

            return RedirectToAction("Create","Acessorios",produto.Linha);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            
            var obj = facade.ConsultarId(new Produto(), id.Value);
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Esse produto não existe" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)
        {            
            var obj = facade.ConsultarId(new Produto(), id);
            facade.Excluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            
            var obj = facade.ConsultarId(new Produto(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Esse produto não existe" });
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            
            var obj = facade.ConsultarId(new Produto(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Esse produto não existe" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {

            if (id != produto.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Produto escolhido pra editar não existe" });
            }

            try
            {                
                facade.Alterar(produto);
                return RedirectToAction("Index");
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }            
        }

        public IActionResult Consultar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Consultar(Produto produto)
        {           
            var prod = facade.ConsultarFiltro(produto);
            return View("ResultadoFiltro",prod);           
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
