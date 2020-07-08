using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using CadastroProduto.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Facade
{
    public class ProdutoFacade :IFacade
    {
        private readonly DataBaseContext dbContext;

        public ProdutoFacade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {
            ValidarDadosProduto validar = new ValidarDadosProduto();
            var conf = validar.Processar(entidadeDominio);

            if (conf == null)
            {
                Produto p = (Produto)entidadeDominio;
                ProdutoDAL pd = new ProdutoDAL(dbContext);
                pd.Cadastrar(entidadeDominio);
                Log classe = new Log();
                GerarLog log = new GerarLog();
                classe.Descricao = log.Processar(entidadeDominio);
                classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do produto: " +p.Nome + ", " + p.Codigo + ", " + p.DataEntrada + ", "
                    + p.Quantidade + ", " + p.Status + ", " + p.Valor + ", " + p.Cliente.Nome + ", " + p.Linha.Nome+"]";

                LogDAL dal = new LogDAL(dbContext);
                dal.GerarLog(classe);
                return null;

            }

            return conf;

        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            Produto p = (Produto)entidadeDominio;
            ProdutoDAL pd = new ProdutoDAL(dbContext);
            pd.Alterar(entidadeDominio);
            Log classe = new Log();
            GerarLog log = new GerarLog();
            classe.Descricao = log.Processar(entidadeDominio);
            classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do produto: " + p.Nome + ", " + p.Codigo + ", " + p.DataEntrada + ", "
                + p.Quantidade + ", " + p.Status + ", " + p.Valor + ", "  + "]";

            LogDAL dal = new LogDAL(dbContext);
            dal.GerarLog(classe);
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
           
            ProdutoDAL dal = new ProdutoDAL(dbContext);
            dal.Excluir(entidadeDominio);
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            ProdutoDAL pd = new ProdutoDAL(dbContext);
            List<EntidadeDominio> list = new List<EntidadeDominio>();
            list = pd.Consultar(entidadeDominio);
            return list;
        }

        public Produto ConsultarId(int id)
        {
            ProdutoDAL dal = new ProdutoDAL(dbContext);
            return dal.ConsultarId(id);
        }

        public ICollection<Produto> ConsultarFiltro(Produto produto)
        {
            ProdutoDAL dal = new ProdutoDAL(dbContext);
            var prod = dal.ConsultarFiltro(produto);
            return prod;
        }

        
    }
}
