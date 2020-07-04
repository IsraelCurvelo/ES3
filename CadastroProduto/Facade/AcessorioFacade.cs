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

        public void Cadastrar(EntidadeDominio entidadeDominio)
        {
            ValidarDadosAcessorio validar = new ValidarDadosAcessorio();
            var conf = validar.Processar(entidadeDominio);
            if (conf != null)
            {
                AcessorioDAL cd = new AcessorioDAL(dbContext);
                cd.Cadastrar(entidadeDominio);
                GerarLog log = new GerarLog();
                log.Processar(entidadeDominio);
            }

        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            AcessorioDAL dal = new AcessorioDAL(dbContext);
            dal.Alterar(entidadeDominio);
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
