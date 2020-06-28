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
            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in lf.Consultar(linha))
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
          
        }


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AcessorioFacade facade = new AcessorioFacade(dbContext);
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
            AcessorioFacade facade = new AcessorioFacade(dbContext);
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
            AcessorioFacade facade = new AcessorioFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Sair()
        {
            
            return RedirectToAction("Index", "Produtos");
        }       

       

        public IActionResult CreateLinha()
        {
            return RedirectToAction("Create", "Linhas");
        }
        
    }
}
