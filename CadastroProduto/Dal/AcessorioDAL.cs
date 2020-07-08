﻿using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class AcessorioDAL : IDAL
    {
        private readonly DataBaseContext dbContext;
        public AcessorioDAL(DataBaseContext dbContext)
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
            if (!dbContext.Acessorio.Any(x => x.Id == entidadeDominio.Id))
            {
                throw new ApplicationException("Acessório não encontrado");
            }

            try
            {
                dbContext.Update(entidadeDominio);
                dbContext.SaveChanges();
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            dbContext.Remove(entidadeDominio);
            dbContext.SaveChanges();
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            var list = dbContext.Acessorio.ToList();
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;
        }

        public Acessorio ConsultarId(int id)
        {

            var acessorio =  dbContext.Acessorio
                .Include(x=>x.Linha )
                .FirstOrDefault(x => x.Id == id);

            if(acessorio == null)
            {
                return null;
            }

            return acessorio;

        }
    }
}
