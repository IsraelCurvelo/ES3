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
    public class UsuariosController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly Facade facade;

        public UsuariosController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            facade = new Facade(dbContext);
        }

        public IActionResult Index()
        {
            Usuario usuario = new Usuario();            

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
            var conf = facade.Cadastrar(usuario);
            
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
