using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CadastroProduto.Models.Domain;
using CadastroProduto.Fachada;
using CadastroProduto.Data;
using CadastroProduto.Models.ViewModels;

namespace CadastroProduto.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly Facade facade;

        public HomeController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            facade = new Facade(dbContext);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexUsuario(Usuario usuario)
        {
            return View(usuario);
        }

        public IActionResult Create()
        {
            return RedirectToAction("Create","Usuarios");
        }

        public IActionResult CreateU()
        {
            return RedirectToAction("Create", "Produtos");
        }

        public IActionResult Login(Usuario usuario)
        {           
            bool confirmacao = facade.Login(usuario);
            if (confirmacao)
            {
                Usuario logado = facade.ConsultarEmail(usuario.Email);
                return RedirectToAction("IndexUsuario", "Home", logado);
            }

            return RedirectToAction("Error","Home",new  { message = "Email ou senha incorreto!"});
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
