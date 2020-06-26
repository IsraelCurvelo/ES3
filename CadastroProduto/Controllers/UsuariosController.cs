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
    public class UsuariosController : Controller
    {
       private readonly DataBaseContext dbContext;
        
        public UsuariosController(DataBaseContext dbContext)
        {
           this.dbContext = dbContext;          
        }

        public IActionResult Index()
        {
            Usuario usuario = new Usuario();
            UsuarioFacade uf = new UsuarioFacade(dbContext);    
            
            List<Usuario> resultado = new List<Usuario>();
            foreach (EntidadeDominio x in uf.Consultar(usuario))
            {
                resultado.Add((Usuario)x);
            }
            return View(resultado);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Usuario usuario)
        {
             UsuarioFacade uf = new UsuarioFacade(dbContext);
             uf.Cadastrar(usuario);
            
            return RedirectToAction("IndexUsuario", "Home",usuario);

        }

    }
}
