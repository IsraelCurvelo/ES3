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
    public class ClientesController : Controller
    {
        private readonly DataBaseContext dbContext;
        private readonly Facade facade;

        public ClientesController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            facade = new Facade(dbContext);
        }

        public IActionResult Index()
        {
            Cliente cliente = new Cliente();          

            List<Cliente> resultado = new List<Cliente>();
            foreach (EntidadeDominio item in facade.Consultar(cliente))
            {
                resultado.Add((Cliente)item);
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
            string confirmacao = facade.Cadastrar(cliente);           
            return RedirectToAction(nameof(Index));        
        }

        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                        
            Cliente cliente = (Cliente)facade.ConsultarId(new Cliente() { Id = id.Value });
            if (cliente == null) return RedirectToAction(nameof(Error), new { message = "Cliente não cadastrado" });
            
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {            
            Cliente cliente = (Cliente)facade.ConsultarId(new Cliente() { Id = id });
            facade.Excluir(cliente);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                      
            Cliente cliente = (Cliente)facade.ConsultarId(new Cliente() { Id = id.Value });
            if (cliente == null) return RedirectToAction(nameof(Error), new { message = "Cliente não cadastrado" });
            
            return View(cliente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
                        
            Cliente cliente = (Cliente)facade.ConsultarId(new Cliente() { Id = id.Value });

            if (cliente == null) return RedirectToAction(nameof(Error), new { message = "Cliente não cadastrado" });
           
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente)
        {
            if (id != cliente.Id) return RedirectToAction(nameof(Error), new { message = "Cliente selecionado para editar diferente do que está cadastrado" });
            
            try
            {                
                facade.Alterar(cliente);        
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
    }
}
