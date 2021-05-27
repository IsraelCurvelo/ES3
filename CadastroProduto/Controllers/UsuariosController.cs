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
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;


namespace CadastroProduto.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly DataBaseContext dbContext;

        public UsuariosController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Usuario usuario = new Usuario();
            Facade facade = new Facade(dbContext);

            List<Usuario> resultado = new List<Usuario>();
            foreach (EntidadeDominio x in facade.Consultar(usuario))
            {
                resultado.Add((Usuario)x);
            }
            return View(resultado);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
            Facade fachada = new Facade(dbContext);
            var conf = fachada.Cadastrar(usuario);
            
            if (conf != null)
            {
                return RedirectToAction(nameof(Error), new { message = conf});
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            Facade facade = new Facade(dbContext);
            var obj = facade.ConsultarId(new Usuario(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Facade facade = new Facade(dbContext);
            var obj = facade.ConsultarId(new Usuario(), id);

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
            var obj = facade.ConsultarId(new Usuario(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
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
            var obj = facade.ConsultarId(new Usuario(), id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Usuario usuario)
        {
            if(id != usuario.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
            }

            try
            {
                Facade facade = new Facade(dbContext);
                facade.Alterar(usuario);

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

        public IActionResult Sair()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
