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

        public void Cadastrar(EntidadeDominio entidadeDominio)
        {
            ValidarDadosProduto validar = new ValidarDadosProduto();
            var conf = validar.Processar(entidadeDominio);

            if (conf != null)
            {
                ProdutoDAL pd = new ProdutoDAL(dbContext);
                pd.Cadastrar(entidadeDominio);
                GerarLog log = new GerarLog();
                log.Processar(entidadeDominio);
            }                    
            

        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            ProdutoDAL dal = new ProdutoDAL(dbContext);
            dal.Alterar(entidadeDominio);
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
    }
}
