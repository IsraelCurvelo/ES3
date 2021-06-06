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

            List<Acessorio> listaAcessorio = new List<Acessorio>();
            foreach (EntidadeDominio item in facade.Consultar(acessorio)) listaAcessorio.Add((Acessorio)item);
            
            return View(listaAcessorio);
        }

        public IActionResult Create(Linha linha)
        {
            List<Linha> listaLinha = new List<Linha>();            
            foreach (EntidadeDominio item in facade.Consultar(linha)) listaLinha.Add((Linha)item);
                        
            var viewModel = new AcessorioBasicoFormViewModel { Linhas = listaLinha };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Acessorio acessorio)
        {         
          string confirmacao = facade.Cadastrar(acessorio);

            if (confirmacao != null) return RedirectToAction(nameof(Error), new { message = confirmacao });
            
            return RedirectToAction("Create", "Acessorios", acessorio.Linha);          
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                                    
            Acessorio acessorio = (Acessorio)facade.ConsultarId(new Acessorio() { Id = id.Value });
            if (acessorio == null) return RedirectToAction(nameof(Error), new { message = "Acessório não encontrado" });
            
            return View(acessorio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {            
            Acessorio acessorio = (Acessorio)facade.ConsultarId(new Acessorio() { Id = id });
            facade.Excluir(acessorio);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                       
            Acessorio acessorio = (Acessorio)facade.ConsultarId(new Acessorio() { Id = id.Value });

            if (acessorio == null) return RedirectToAction(nameof(Error), new { message = "Acessório não encontrado" });
            
            return View(acessorio);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                       
            Acessorio acessorio = (Acessorio)facade.ConsultarId(new Acessorio() { Id = id.Value });

            if (acessorio == null) return RedirectToAction(nameof(Error), new { message = "Acessório não encontrado" });                    
            
            List<Linha> listaLinha = new List<Linha>();            
            foreach (EntidadeDominio item in facade.Consultar(acessorio.Linha)) listaLinha.Add((Linha)item);
            
            var viewModel = new AcessorioBasicoFormViewModel { Acessorio = acessorio, Linhas = listaLinha };

            return View(viewModel);             
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Acessorio acessorio)
        {
            if (id != acessorio.Id) return RedirectToAction(nameof(Error), new { message = "Acessório escolhido para cadastrar diferente do cadastrado" });
            
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
