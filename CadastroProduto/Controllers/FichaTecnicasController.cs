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
    public class FichaTecnicasController : Controller
    {
        private readonly DataBaseContext dbContext;
        
        public FichaTecnicasController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            FichaTecnica fichaTecnica = new FichaTecnica();
            Facade facade = new Facade(dbContext);

            List<FichaTecnica> resultado = new List<FichaTecnica>();
            foreach (EntidadeDominio x in facade.Consultar(fichaTecnica))
            {
                resultado.Add((FichaTecnica)x);
            }
            return View(resultado);
        }

        public IActionResult Create()
        {   
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FichaTecnica fichaTecnica)
        {
            Facade facade = new Facade(dbContext);            
            var conf = facade.Cadastrar(fichaTecnica);

            if(conf != null)
            {
                return RedirectToAction(nameof(Error), new { message = conf });
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            Facade facade = new Facade(dbContext);
            var obj = facade.ConsultarId(new FichaTecnica(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Ficha Técnica não encontrada" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Facade facade = new Facade(dbContext);
            var obj = facade.ConsultarId(new FichaTecnica(), id);

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
            var obj = facade.ConsultarId(new FichaTecnica(), id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Ficha Técnica não encontrada" });
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
            var obj = facade.ConsultarId(new FichaTecnica(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Ficha Técnica não encontrada" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, FichaTecnica fichaTecnica)
        {

            if (id != fichaTecnica.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Ficha Técnica selecionada diferente da que está cadastrada" });
            }

            try
            {
                Facade facade = new Facade(dbContext);
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
