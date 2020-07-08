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
            
            Linha linha = (Linha)entidadeDominio;
            Log classe = new Log();
            GerarLog log = new GerarLog();
            classe.Descricao = log.Processar(entidadeDominio);
            classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados da linha: " + linha.Nome + ", " + linha.Codigo + "]";

            LogDAL dal = new LogDAL(dbContext);
            dal.GerarLog(classe);
            return null;
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            LinhaDAL dal = new LinhaDAL(dbContext);
            dal.Alterar(entidadeDominio);

            Linha linha = (Linha)entidadeDominio;
            Log classe = new Log();
            GerarLog log = new GerarLog();
            classe.Descricao = log.Processar(entidadeDominio);
            classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados da linha: " + linha.Nome + ", " + linha.Codigo + "]";

            LogDAL ldal = new LogDAL(dbContext);
            ldal.GerarLog(classe);
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