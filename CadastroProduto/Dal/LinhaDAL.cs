using CadastroProduto.Controllers;
using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class LinhaDAL :IDAL
    {
        private readonly DataBaseContext dbContext;
      
        public LinhaDAL(DataBaseContext dbContext)
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
            if (!dbContext.Linha.Any(x => x.Id == entidadeDominio.Id))
            {
                throw new NotFoundException("Linha não encontrada");
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
            
            var list = dbContext.Linha.ToList();
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;
        }

        public Linha ConsultarPorId(int id)
        {
            var linha = dbContext.Linha
                .Include(obj => obj.FichaTecnicaLinha)
                .Include(obj => obj.Acessorio)                
                .FirstOrDefault(x => x.Id == id);
            
            if (linha == null)
            {
                return null;
            }
            var acessorios = dbContext.Acessorio.Where(x => x.LinhaId == id).ToList();            

            Linha linhaA = new Linha { Id = linha.Id, Codigo = linha.Codigo, Nome = linha.Nome, FichaTecnicaLinha = linha.FichaTecnicaLinha, Acessorios = acessorios };
            return linhaA;

        }

        public Linha ConsultarRemover(int id)
        {
            var linha = dbContext.Linha              
                .FirstOrDefault(x => x.Id == id);

            return linha;
        }

    }
}
