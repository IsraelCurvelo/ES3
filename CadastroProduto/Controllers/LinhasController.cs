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

namespace CadastroProduto.Controllers
{
    public class LinhasController : Controller
    {
        private readonly DataBaseContext dbContext;       

        public LinhasController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Linha linha = new Linha();            
            LinhaFacade lf = new LinhaFacade(dbContext);

            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in lf.Consultar(linha))
            {
                resultado.Add((Linha)x);
            }
            return View(resultado);

        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Linha linha)
        {
           LinhaFacade lf = new LinhaFacade(dbContext);
           var conf =  lf.Cadastrar(linha);


            return RedirectToAction("Create","Acessorios",linha);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
           LinhaFacade facade = new LinhaFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Linha não encontrada" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            LinhaFacade facade = new LinhaFacade(dbContext);
            
            var obj = facade.ConsultarRemover(id);
            facade.Excluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            LinhaFacade facade = new LinhaFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Linha não encontrada" });
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            LinhaFacade facade = new LinhaFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Linha não encontrada" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Linha linha)
        {

            if (id != linha.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Linha escolhida para editar diferente da cadastrada" });
            }

            try
            {
                LinhaFacade facade = new LinhaFacade(dbContext);
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
