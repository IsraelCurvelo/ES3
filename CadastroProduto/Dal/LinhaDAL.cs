using CadastroProduto.Data;
using CadastroProduto.Models.Domain;
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

        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {

        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            var list = dbContext.Linha.Where(x => x.Id == entidadeDominio.Id);
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;
        }

        public Linha ConsultarPorId(int id)
        {
            return dbContext.Linha.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
