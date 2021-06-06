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
    public class LinhasController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly Facade facade;

        public LinhasController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            facade = new Facade(dbContext);
        }

        public IActionResult Index()
        {
            Linha linha = new Linha();            

            List<Linha> listaLinha = new List<Linha>();
            foreach (EntidadeDominio x in facade.Consultar(linha)) listaLinha.Add((Linha)x);
            
            return View(listaLinha);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Linha linha)
        {                    
            string confirmacao = facade.Cadastrar(linha);
            return RedirectToAction("Create", "Acessorios", linha);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                        
            Linha linha = (Linha)facade.ConsultarId(new Linha() { Id = id.Value });
            if (linha == null) return RedirectToAction(nameof(Error), new { message = "Linha não encontrada" });
            
            return View(linha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {     
            Linha linhaRemover = facade.ConsultarRemover(id);
            facade.Excluir(linhaRemover);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                        
            Linha linha = (Linha)facade.ConsultarId(new Linha() { Id = id.Value });
            if (linha == null) return RedirectToAction(nameof(Error), new { message = "Linha não encontrada" });
            
            return View(linha);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

            Linha linha = (Linha)facade.ConsultarId(new Linha() { Id = id.Value });
            if (linha == null) return RedirectToAction(nameof(Error), new { message = "Linha não encontrada" });
            
            return View(linha);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Linha linha)
        {

            if (id != linha.Id) return RedirectToAction(nameof(Error), new { message = "Linha escolhida para editar diferente da cadastrada" });
            
            try
            {               
                facade.Alterar(linha);
                return RedirectToAction("Index");
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
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
