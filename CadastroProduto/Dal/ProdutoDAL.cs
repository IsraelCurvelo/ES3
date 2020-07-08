using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Models.Domain;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class ProdutoDAL : IDAL
    {
        private readonly DataBaseContext dbContext;
        public ProdutoDAL(DataBaseContext dbContext)
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
            if (!dbContext.Produto.Any(x => x.Id == entidadeDominio.Id))
            {
                throw new ApplicationException("Produto não encontrado");
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
            var list = dbContext.Produto.ToList();
            List<EntidadeDominio> resultado = new List<EntidadeDominio>();
            foreach (EntidadeDominio x in list)
            {
                resultado.Add(x);
            }

            return resultado;
        }

        public Produto ConsultarId(int id)
        {
            try
            {
                var produto = dbContext.Produto
                    .Include(obj => obj.Cliente)
                    .Include(obj => obj.Cliente.Endereco)
                    .Include(obj => obj.Cliente.Endereco.Cidade)
                    .Include(obj => obj.Cliente.Endereco.Cidade.Estado)
                    .Include(obj => obj.FichaTecnica)
                    .Include(obj => obj.FichaTecnica.Componente)
                    .Include(obj => obj.FichaTecnica.Categoria)
                    .Include(obj => obj.FichaTecnica.Categoria.SubCategoria)
                    .Include(obj => obj.Linha)
                    .FirstOrDefault(x => x.Id == id);

                if (produto == null)
                {
                    return null;
                }
                LinhaDAL dal = new LinhaDAL(dbContext);
                var linha = dal.ConsultarPorId(produto.Linha.Id);
                produto.Linha = linha;

                return produto;
            }
            catch (ApplicationException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public ICollection<Produto> ConsultarFiltro(Produto produto)
        {
            HashSet<Produto> consulta = new HashSet<Produto>();


            if (produto.Codigo != null)
            {
                var resultado = dbContext.Produto.Where(x => x.Codigo == produto.Codigo).ToList();
                foreach (Produto item in resultado)
                {
                    var prod = ConsultarId(item.Id);
                    consulta.Add(prod);
                }
            }

            if (produto.Nome != null)
            {
                var resultado = dbContext.Produto.Where(x => x.Nome == produto.Nome).ToList();
                
                foreach (Produto item in resultado)
                {
                    var prod = ConsultarId(item.Id);
                    consulta.Add(prod);
                }
            }

            if (produto.Valor >= 0.0)
            {
                var resultado = dbContext.Produto.Where(x => x.Valor == produto.Valor).ToList();
                foreach (Produto item in resultado)
                {
                    var prod = ConsultarId(item.Id);
                    consulta.Add(prod);
                }
            }

            if (produto.DataEntrada != null)
            {
                var resultado = dbContext.Produto.Where(x => x.DataEntrada == produto.DataEntrada).ToList();
                foreach (Produto item in resultado)
                {
                    var prod = ConsultarId(item.Id);
                    consulta.Add(prod);
                }
            }

            if (produto.Quantidade >= 0)
            {
                var resultado = dbContext.Produto.Where(x => x.Quantidade == produto.Quantidade).ToList();
                foreach (Produto item in resultado)
                {
                    var prod = ConsultarId(item.Id);
                    consulta.Add(prod);
                }
            }

            if (produto.Status)
            {
                var resultado = dbContext.Produto.Where(x => x.Status == true).ToList();
                foreach (Produto item in resultado)
                {
                    var prod = ConsultarId(item.Id);
                    consulta.Add(prod);
                }
            }
            else if(!produto.Status)
            {
                var resultado = dbContext.Produto.Where(x => x.Status == false).ToList();
                foreach (Produto item in resultado)
                {
                    var prod = ConsultarId(item.Id);
                    consulta.Add(prod);
                }

            }           

            

            if (produto.FichaTecnica.Nome != null)
            {
                var resultado = dbContext.FichaTecnica.Where(x => x.Nome == produto.FichaTecnica.Nome).ToList();                
                foreach (FichaTecnica item in resultado)
                {
                    Produto p = dbContext.Produto.Where(x => x.FichaTecnica.Id == item.Id).FirstOrDefault();
                    var prod = ConsultarId(p.Id);
                    consulta.Add(prod);
                }
            }

            if (produto.Cliente.Nome != null)
            {
                var resultado = dbContext.Cliente.Where(x => x.Nome == produto.Cliente.Nome).ToList();
                foreach (Cliente item in resultado)
                {
                    Produto p = dbContext.Produto.Where(x => x.Cliente.Id == item.Id).FirstOrDefault();
                    var prod = ConsultarId(p.Id);
                    consulta.Add(prod);
                }
            }

            return consulta;
        }
    }
}
