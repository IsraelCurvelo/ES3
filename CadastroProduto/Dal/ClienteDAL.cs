using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class ClienteDAL :IDAL
    {
        private readonly DataBaseContext dbContext;
        public ClienteDAL(DataBaseContext dbContext)
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
            
            if (!dbContext.Cliente.Any(x => x.Id == entidadeDominio.Id))
            {
                throw new NotFoundException("Cliente não encontrado");
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
            var list = dbContext.Cliente.ToList();
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;
        }

        public Cliente ConsultarId(int id)
        {
            return dbContext.Cliente
                .Include(x => x.Endereco)
                .Include(x => x.Endereco.Cidade)
                .Include(x => x.Endereco.Cidade.Estado)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
