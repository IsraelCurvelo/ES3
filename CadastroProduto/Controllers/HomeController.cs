using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using CadastroProduto.Fachada;
using CadastroProduto.Data;
using CadastroProduto.Models.ViewModels;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace CadastroProduto.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataBaseContext dbContext;

        public HomeController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
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
            Facade facade = new Facade(dbContext);
            var conf = facade.Login(usuario);
            if (conf )
            {
                var logado = facade.ConsultarEmail(usuario.Email);
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
