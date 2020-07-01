﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
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

            return RedirectToAction("Index", "Home");

        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UsuarioFacade facade = new UsuarioFacade(dbContext);
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
            UsuarioFacade facade = new UsuarioFacade(dbContext);
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
            UsuarioFacade facade = new UsuarioFacade(dbContext);
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

            UsuarioFacade facade = new UsuarioFacade(dbContext);
            var obj = facade.ConsultarId(id.Value);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Usuario usuario)
        {

            if(id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                UsuarioFacade facade = new UsuarioFacade(dbContext);
                facade.Alterar(usuario);
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





        public IActionResult Sair()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
