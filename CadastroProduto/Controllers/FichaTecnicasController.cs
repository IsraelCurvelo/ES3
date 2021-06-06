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
    public class FichaTecnicasController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly Facade facade;

        public FichaTecnicasController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            facade = new Facade(dbContext);
        }

        public IActionResult Index()
        {
            FichaTecnica fichaTecnica = new FichaTecnica();           

            List<FichaTecnica> listaFichaTecnica = new List<FichaTecnica>();
            foreach (EntidadeDominio item in facade.Consultar(fichaTecnica)) listaFichaTecnica.Add((FichaTecnica)item);
           
            return View(listaFichaTecnica);
        }

        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FichaTecnica fichaTecnica)
        {                      
            string confirmacao = facade.Cadastrar(fichaTecnica);

            if(confirmacao != null) return RedirectToAction(nameof(Error), new { message = confirmacao });
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                        
            FichaTecnica fichaTecnica = (FichaTecnica)facade.ConsultarId(new FichaTecnica() { Id = id.Value });
            if (fichaTecnica == null) return RedirectToAction(nameof(Error), new { message = "Ficha Técnica não encontrada" });
           
            return View(fichaTecnica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            FichaTecnica fichaTecnica = (FichaTecnica)facade.ConsultarId(new FichaTecnica() { Id = id });

            facade.Excluir(fichaTecnica);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

            FichaTecnica fichaTecnica = (FichaTecnica)facade.ConsultarId(new FichaTecnica() { Id = id.Value });
            if (fichaTecnica == null) return RedirectToAction(nameof(Error), new { message = "Ficha Técnica não encontrada" });
          
            return View(fichaTecnica);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });

            FichaTecnica fichaTecnica = (FichaTecnica)facade.ConsultarId(new FichaTecnica() { Id = id.Value });
            if (fichaTecnica == null) return RedirectToAction(nameof(Error), new { message = "Ficha Técnica não encontrada" });
           
            return View(fichaTecnica);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FichaTecnica fichaTecnica)
        {

            if (id != fichaTecnica.Id)  return RedirectToAction(nameof(Error), new { message = "Ficha Técnica selecionada diferente da que está cadastrada" });
           
            try
            {                
                facade.Alterar(fichaTecnica);
                return RedirectToAction("Index");
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message});
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
