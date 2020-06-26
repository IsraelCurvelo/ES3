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
            
           // return View();
        }

        public IActionResult Create()
        {
            /*
            EntidadeDominio fichaTecnica = new FichaTecnica();
            FichaTecnicaFacade lf = new FichaTecnicaFacade(dbContext);

            List<FichaTecnica> resultadoFichaTecnica = new List<FichaTecnica>();
            foreach (EntidadeDominio x in lf.Consultar(fichaTecnica))
            {
                resultadoFichaTecnica.Add((FichaTecnica)x);
            }
            EntidadeDominio cliente = new Cliente();
            ClienteFacade cf = new ClienteFacade(dbContext);

            List<Cliente> resultadoCliente = new List<Cliente>();
            foreach (EntidadeDominio x in cf.Consultar(cliente))
            {
                resultadoCliente.Add((Cliente)x);
            }


            var viewModel = new ProdutoViewModel { FichaTecnica = resultadoFichaTecnica, Cliente = resultadoCliente };
            return View(viewModel);
            */
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
    }
}
