﻿using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Facade
{
    public class UsuarioFacade :IFacade
    {
       private readonly DataBaseContext dbContext;
        
        public UsuarioFacade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;           
        }

        public void Cadastrar(EntidadeDominio entidadeDominio)
        {
           // usuario.ValidarSenha();
           // usuario.ValidarLogin();
           // usuario.CriptografarSenha();


            UsuarioDAL ud = new UsuarioDAL(dbContext);
            ud.Cadastrar(entidadeDominio);
            Log.Gerar(new Dictionary<string, string>());

        }

        public void Alterar (EntidadeDominio entidadeDominio)
        {

            UsuarioDAL dal = new UsuarioDAL(dbContext);
            dal.Alterar(entidadeDominio);
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            UsuarioDAL dal = new UsuarioDAL(dbContext);
            dal.Excluir(entidadeDominio);
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            UsuarioDAL ud = new UsuarioDAL(dbContext);

            List<EntidadeDominio> list = new List<EntidadeDominio>();
            list=ud.Consultar(entidadeDominio);
            return list;
        }

        public Usuario ConsultarId(int id)
        {
            UsuarioDAL dal = new UsuarioDAL(dbContext);
            return dal.ConsultarId(id);
        }

    }
}
