using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
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

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ClienteFacade facade = new ClienteFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            ClienteFacade facade = new ClienteFacade(dbContext);
            var obj = facade.ConsultarId(id);
            facade.Excluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ClienteFacade facade = new ClienteFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ClienteFacade facade = new ClienteFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {

            if (id != cliente.Id)
            {
                return BadRequest();
            }

            try
            {
                ClienteFacade facade = new ClienteFacade(dbContext);
                facade.Alterar(cliente);           



                return RedirectToAction("Index");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (DbException)
            {
                return BadRequest();
            }
        }
    }
}
