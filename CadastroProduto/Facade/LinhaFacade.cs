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
    public class LinhaFacade :IFacade
    {
        private readonly DataBaseContext dbContext;
        
        public LinhaFacade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;           
        }

        public LinhaFacade()
        {
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {           
            LinhaDAL ld = new LinhaDAL(dbContext);
            ld.Cadastrar(entidadeDominio);
            GerarLog log = new GerarLog();
            var res = log.Processar(entidadeDominio);
            return null;
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            LinhaDAL dal = new LinhaDAL(dbContext);
            dal.Alterar(entidadeDominio);
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            LinhaDAL dal = new LinhaDAL(dbContext);
            dal.Excluir(entidadeDominio);
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            LinhaDAL ld = new LinhaDAL(dbContext);

            List<EntidadeDominio> list = new List<EntidadeDominio>();
            list = ld.Consultar(entidadeDominio);
            return list;
        }

        public Linha ConsultarId(int id)
        {           
                LinhaDAL ld = new LinhaDAL(dbContext);            
                var obj = ld.ConsultarPorId(id);
                return obj;            
        }

        public Linha ConsultarRemover(int id)
        {
            LinhaDAL ld = new LinhaDAL(dbContext);
            var obj = ld.ConsultarRemover(id);
            return obj;
        }


    }
}