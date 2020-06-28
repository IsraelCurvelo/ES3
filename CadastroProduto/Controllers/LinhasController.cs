using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Facade;
using CadastroProduto.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CadastroProduto.Controllers
{
    public class LinhasController : Controller
    {
        private readonly DataBaseContext dbContext;       

        public LinhasController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            Linha linha = new Linha();            
            LinhaFacade lf = new LinhaFacade(dbContext);

            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in lf.Consultar(linha))
            {
                resultado.Add((Linha)x);
            }
            return View(resultado);

        }

        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Linha linha)
        {
           LinhaFacade lf = new LinhaFacade(dbContext);
            lf.Cadastrar(linha);


            return RedirectToAction("Create","Acessorios",linha);

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           LinhaFacade facade = new LinhaFacade(dbContext);
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
            LinhaFacade facade = new LinhaFacade(dbContext);
            
            var obj = facade.ConsultarRemover(id);
            facade.Excluir(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            LinhaFacade facade = new LinhaFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
    }
}
