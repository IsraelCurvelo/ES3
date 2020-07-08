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
    public class FichaTecnicaFacade :IFacade
    {
        private readonly DataBaseContext dbContext;
       
        public FichaTecnicaFacade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;            
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {
            ValidarDadosFichaTecnica validar = new ValidarDadosFichaTecnica();
            var conf = validar.Processar(entidadeDominio);

            if(conf == null)
            {
                FichaTecnicaDAL ftd = new FichaTecnicaDAL(dbContext);
                ftd.Cadastrar(entidadeDominio);

                FichaTecnica ficha = (FichaTecnica)entidadeDominio;
                Log classe = new Log();
                GerarLog log = new GerarLog();
                classe.Descricao = log.Processar(entidadeDominio);
                classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados da Ficha Técnica: " + ficha.Nome + ", " + ficha.Codigo + "]";

                LogDAL dal = new LogDAL(dbContext);
                dal.GerarLog(classe);
                return null;
            }
            return conf;

        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            FichaTecnicaDAL dal = new FichaTecnicaDAL(dbContext);
            dal.Alterar(entidadeDominio);

            FichaTecnica ficha = (FichaTecnica)entidadeDominio;
            Log classe = new Log();
            GerarLog log = new GerarLog();
            classe.Descricao = log.Processar(entidadeDominio);
            classe.Descricao = classe.Descricao + ", [Tipo: Alteração], [Dados da Ficha Técnica: " + ficha.Nome + ", " + ficha.Codigo + "]";

            LogDAL logdal = new LogDAL(dbContext);
            logdal.GerarLog(classe);
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            FichaTecnicaDAL dal = new FichaTecnicaDAL(dbContext);
            dal.Excluir(entidadeDominio);
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            List<EntidadeDominio> list = new List<EntidadeDominio>();
            FichaTecnicaDAL ftd = new FichaTecnicaDAL(dbContext);
            list = ftd.Consultar(entidadeDominio);
            return list;
        }

        public FichaTecnica ConsultarId(int id)
        {
            FichaTecnicaDAL dal = new FichaTecnicaDAL(dbContext);
            var obj = dal.ConsultarId(id);
            return obj;
        }
    }
}
