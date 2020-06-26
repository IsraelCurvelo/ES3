using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Facade;
using CadastroProduto.Models.Domain;
using CadastroProduto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CadastroProduto.Controllers
{
    public class AcessoriosController : Controller
    {
        private readonly DataBaseContext dbContext;        
        
        public AcessoriosController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;          
        }

        public IActionResult Index()
        {
            Acessorio acessorio = new Acessorio();
            AcessorioFacade abf = new AcessorioFacade(dbContext);

            List<Acessorio> resultado = new List<Acessorio>();
            foreach (EntidadeDominio x in abf.Consultar(acessorio))
            {
                resultado.Add((Acessorio)x);
            }
            return View(resultado);
        }

        public IActionResult Create(Linha linha)
        {
            
            LinhaFacade lf = new LinhaFacade(dbContext);
            Linha lin = lf.ConsultarPorId(linha.Id);
            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in lf.Consultar(lin))
            {
                resultado.Add((Linha)x);
            }

            
            var viewModel = new AcessorioBasicoFormViewModel { Linhas = resultado };

            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Acessorio acessorio)
        {
            
            AcessorioFacade cf = new AcessorioFacade(dbContext);
            cf.Cadastrar(acessorio);

            return RedirectToAction("Create", "Acessorios", acessorio.Linha);

           // return RedirectToAction("Create",acessorio.Linha.Id);
        }             
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sair()
        {
            
            return RedirectToAction("Index", "Produtos");
        }       

       


        
    }
}
