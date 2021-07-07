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
            List<Usuario> listaUsuario = new List<Usuario>();

            foreach (EntidadeDominio x in facade.Consultar(usuario))
                listaUsuario.Add((Usuario)x);
            
            return View(listaUsuario);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {          
            string conf = facade.Cadastrar(usuario);
            
            if (conf != null) 
                return RedirectToAction(nameof(Error), new { message = conf});
            
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            
            Usuario usuario = (Usuario)facade.ConsultarId(new Usuario() { Id = id.Value });

            if (usuario == null) 
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
            
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {            
            Usuario usuario = (Usuario)facade.ConsultarId(new Usuario() { Id = id });
            facade.Excluir(usuario);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                        
            Usuario usuario = (Usuario)facade.ConsultarId(new Usuario() { Id = id.Value });

            if (usuario == null) 
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
            
            return View(usuario);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) 
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            
            Usuario usuario = (Usuario)facade.ConsultarId(new Usuario() { Id = id.Value });

            if (usuario == null) 
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
            
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Usuario usuario)
        {
            if(id != usuario.Id) 
                return RedirectToAction(nameof(Error), new { message = "Esse usuário não existe" });
            
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
