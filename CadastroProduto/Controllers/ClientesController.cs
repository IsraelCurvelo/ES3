using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Facade;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;

using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.Controllers
{
    public class ClientesController : Controller
    {
        private readonly DataBaseContext dbContext;       

        public ClientesController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;         

        }

        public IActionResult Index()
        {
            Cliente cliente = new Cliente();
            ClienteFacade cf = new ClienteFacade(dbContext);

            List<Cliente> resultado = new List<Cliente>();
            foreach (EntidadeDominio x in cf.Consultar(cliente))
            {
                resultado.Add((Cliente)x);
            }
            return View(resultado);


        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente)
        {
            
            ClienteFacade cf = new ClienteFacade(dbContext);
            cf.Cadastrar(cliente);

            return RedirectToAction(nameof(Index));
            //return RedirectToAction("Create", "Produtos");

        }
    }
}
