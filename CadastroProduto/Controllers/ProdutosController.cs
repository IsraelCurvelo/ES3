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

        public IActionResult Index()
        {            
            Produto produto = new Produto();          

            List<Produto> listaProduto = new List<Produto>();
            foreach (EntidadeDominio item in facade.Consultar(produto))  listaProduto.Add((Produto)item);
            
            return View(listaProduto);         
        }

        public IActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {                    
            string confirmacao = facade.Cadastrar(produto);
            
            if (confirmacao != null) return RedirectToAction(nameof(Error), new { message = confirmacao });
          
            return RedirectToAction("Create","Acessorios",produto.Linha);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)  return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                        
            Produto produto = (Produto)facade.ConsultarId(new Produto() { Id = id.Value });
            if(produto == null)  return RedirectToAction(nameof(Error), new { message = "Esse produto não existe" });
            
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)
        {                       
            Produto produto = (Produto)facade.ConsultarId(new Produto() { Id = id });
            facade.Excluir(produto);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

            Produto produto = (Produto)facade.ConsultarId(new Produto() { Id = id.Value });
            if (produto == null) return RedirectToAction(nameof(Error), new { message = "Esse produto não existe" });
           
            return View(produto);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)  return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

            Produto produto = (Produto)facade.ConsultarId(new Produto() { Id = id.Value });
            if (produto == null)  return RedirectToAction(nameof(Error), new { message = "Esse produto não existe" });
                      
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {

            if (id != produto.Id) return RedirectToAction(nameof(Error), new { message = "Produto escolhido pra editar não existe" });
            
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
            var listaProdutos = facade.ConsultarFiltroProdutos(produto);
            return View("ResultadoFiltro", listaProdutos);           
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
