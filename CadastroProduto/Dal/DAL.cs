using CadastroProduto.Data;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CadastroProduto.Dal
{
    public class DAL : IDAL
    {
        protected readonly DataBaseContext dbContext;
        public DAL(DataBaseContext dbContext)
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
                throw new ApplicationException("Objeto não encontrado");
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
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();

            switch (entidadeDominio.GetType().Name.ToLower())
            {
                case ("acessorio"):                   
                    foreach (EntidadeDominio x in dbContext.Acessorio.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;
                    
                case ("usuario"):                   
                    foreach (EntidadeDominio x in dbContext.Usuario.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;   

                case ("cliente"):                   
                    foreach (EntidadeDominio x in dbContext.Cliente.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;  
                case ("produto"):                   
                    foreach (EntidadeDominio x in dbContext.Produto.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado; 
                case ("linha"):                   
                    foreach (EntidadeDominio x in dbContext.Linha.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;    
                case ("fichatecnica"):                   
                    foreach (EntidadeDominio x in dbContext.FichaTecnica.ToList())
                    {
                        resultado.Add(x);
                    }
                    return resultado;
                default: 
                    return null;
            }           
        }

        public EntidadeDominio ConsultarId(int id)
        {

            var acessorio = dbContext.Acessorio
                .Include(x => x.Linha)
                .FirstOrDefault(x => x.Id == id);
            if (acessorio != null) return acessorio; 
            else return null;
          
        }

        public void GerarLog(Log log)
        {            
            dbContext.Add(log);
            dbContext.SaveChanges();

        }

    }
}
