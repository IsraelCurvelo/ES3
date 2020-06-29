using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;

namespace CadastroProduto.Controllers
{
    public class HomeController : Controller
    {
        
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
            // implementar

            return RedirectToAction("IndexUsuario", "Home", usuario);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
