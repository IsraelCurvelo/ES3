using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Fachada;
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
            Facade facade = new Facade(dbContext);

            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in facade.Consultar(linha))
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
            Facade facade = new Facade(dbContext);            
            var conf = facade.Cadastrar(linha);

            return RedirectToAction("Create", "Acessorios", linha);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            Facade facade = new Facade(dbContext);
            var obj = facade.ConsultarId(new Linha(), id.Value);
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
            Facade facade = new Facade(dbContext);

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
            Facade facade = new Facade(dbContext);
            var obj = facade.ConsultarId(new Linha(), id.Value);

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

            Facade facade = new Facade(dbContext);
            var obj = facade.ConsultarId(new Linha(), id.Value);

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
                Facade facade = new Facade(dbContext);
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
