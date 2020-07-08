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
    public class FichaTecnicaDAL :IDAL
    {
        private readonly DataBaseContext dbContext;        

        public FichaTecnicaDAL(DataBaseContext dbContext)
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
            if (!dbContext.FichaTecnica.Any(x => x.Id == entidadeDominio.Id))
            {
                throw new NotFoundException("Ficha Técnica não encontrada");
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
            var list = dbContext.FichaTecnica.ToList();
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;
        }

        public FichaTecnica ConsultarId(int id)
        {
            return dbContext.FichaTecnica
                .Include(x => x.Componente)
                .Include(x => x.Categoria)
                .Include(x => x.Categoria.SubCategoria)                
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
