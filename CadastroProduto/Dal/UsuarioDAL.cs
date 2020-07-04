﻿using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class UsuarioDAL :IDAL
    {
       private readonly DataBaseContext dbContext;
       
        public UsuarioDAL(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Cadastrar(EntidadeDominio entidadeDominio)
        {            
                dbContext.Add(entidadeDominio);
                dbContext.SaveChanges();            
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            if (!dbContext.Usuario.Any(x => x.Id == entidadeDominio.Id))
            {
                throw new NotFoundException("Usuário não encontrado");
            }

            try
            {
                dbContext.Update(entidadeDominio);
                dbContext.SaveChanges();
            }catch(DbUpdateConcurrencyException e)
            {
                throw new DbException(e.Message);
            }
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            

            dbContext.Remove(entidadeDominio);
            dbContext.SaveChanges();
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            
            var list = dbContext.Usuario.ToList();
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;

        }

        public Usuario ConsultarId(int id)
        {
            return dbContext.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public bool Login(EntidadeDominio entidadeDominio)
        {
            var obj = (Usuario)entidadeDominio;
            var usuarioBanco = dbContext.Usuario.FirstOrDefault(x => x.Email == obj.Email);
            if (usuarioBanco == null)
            {
                throw new NotFoundException("EMAIL NAO ENCONTRADO!");
            }

            if (obj.Senha == usuarioBanco.Senha)
            {
                return true;
            }

            throw new NotFoundException("A SENHA OU EMAIL ESTÁ INCORRETA");
            return false;
        }
    }
}
