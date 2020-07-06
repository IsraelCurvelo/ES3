using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Facade;
using CadastroProduto.Models.Domain;
using CadastroProduto.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly DataBaseContext dbContext;
        
        public ProdutosController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index(Produto produtos)
        {
            
            Produto produto = new Produto();
            ProdutoFacade uf = new ProdutoFacade(dbContext);

            List<Produto> resultado = new List<Produto>();
            foreach (EntidadeDominio x in uf.Consultar(produto))
            {
                resultado.Add((Produto)x);
            }
            return View(resultado);           
         
        }

        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Produto produto)
        {
            
            ProdutoFacade cf = new ProdutoFacade(dbContext);
            cf.Cadastrar(produto);
            

            return RedirectToAction("Create","Acessorios",produto.Linha);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            ProdutoFacade facade = new ProdutoFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete (int id)
        {
            ProdutoFacade facade = new ProdutoFacade(dbContext);
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
            ProdutoFacade facade = new ProdutoFacade(dbContext);
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

            ProdutoFacade facade = new ProdutoFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Produto produto)
        {

            if (id != produto.Id)
            {
                return BadRequest();
            }

            try
            {
                ProdutoFacade facade = new ProdutoFacade(dbContext);
                facade.Alterar(produto);
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

        public IActionResult Consultar()
        {
            return View();
        }
    }
}
