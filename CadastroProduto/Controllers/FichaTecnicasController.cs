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

namespace CadastroProduto.Controllers
{
    public class FichaTecnicasController : Controller
    {
        private readonly DataBaseContext dbContext;
        
        public FichaTecnicasController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            FichaTecnica fichaTecnica = new FichaTecnica();
            FichaTecnicaFacade cf = new FichaTecnicaFacade(dbContext);

            List<FichaTecnica> resultado = new List<FichaTecnica>();
            foreach (EntidadeDominio x in cf.Consultar(fichaTecnica))
            {
                resultado.Add((FichaTecnica)x);
            }
            return View(resultado);
        }

        public IActionResult Create()
        {
            EntidadeDominio linha = new Linha();
            LinhaFacade lf = new LinhaFacade(dbContext);

            List<Linha> resultado = new List<Linha>();
            foreach (EntidadeDominio x in lf.Consultar(linha))
            {
                resultado.Add((Linha)x);
            }
           
            return View(resultado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FichaTecnica fichaTecnica)
        {
            FichaTecnicaFacade cf = new FichaTecnicaFacade(dbContext);
            cf.Cadastrar(fichaTecnica);

            return RedirectToAction(nameof(Index));
        }

    }
}
