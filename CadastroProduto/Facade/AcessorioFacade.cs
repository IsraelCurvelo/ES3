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
    public class AcessorioFacade :IFacade
    {
        private readonly DataBaseContext dbContext;

        public AcessorioFacade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {
            ValidarDadosAcessorio validar = new ValidarDadosAcessorio();
            var conf = validar.Processar(entidadeDominio);
            if (conf == null)
            {
                AcessorioDAL cd = new AcessorioDAL(dbContext);
                cd.Cadastrar(entidadeDominio);

                Acessorio acessorio = (Acessorio)entidadeDominio;
                Log classe = new Log();
                GerarLog log = new GerarLog();
                classe.Descricao = log.Processar(entidadeDominio);
                classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do cliente: " + acessorio.Nome + ", " + acessorio.Codigo + "]";

                LogDAL dal = new LogDAL(dbContext);
                dal.GerarLog(classe);

                return null;
            }
            return conf;
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            AcessorioDAL dal = new AcessorioDAL(dbContext);
            dal.Alterar(entidadeDominio);

            Acessorio acessorio = (Acessorio)entidadeDominio;
            Log classe = new Log();
            GerarLog log = new GerarLog();
            classe.Descricao = log.Processar(entidadeDominio);
            classe.Descricao = classe.Descricao + ", [Tipo: Alteração], [Dados do cliente: " + acessorio.Nome + ", " + acessorio.Codigo + "]";

            LogDAL logdal = new LogDAL(dbContext);
            logdal.GerarLog(classe);
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            AcessorioDAL dal = new AcessorioDAL(dbContext);
            dal.Excluir(entidadeDominio);
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            List<EntidadeDominio> list = new List<EntidadeDominio>();
            AcessorioDAL cd = new AcessorioDAL(dbContext);
            list = cd.Consultar(entidadeDominio);
            return list;
        }

        public Acessorio ConsultarId(int id)
        {
            AcessorioDAL dal = new AcessorioDAL(dbContext);
            return dal.ConsultarId(id);
        }
    }
}
