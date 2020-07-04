using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using CadastroProduto.Facade;
using CadastroProduto.Data;

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
            UsuarioFacade facade = new UsuarioFacade(dbContext);
            var conf = facade.Login(usuario);
            if (conf)
            {
                return RedirectToAction("IndexUsuario", "Home", usuario);
            }

            return RedirectToAction("Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
