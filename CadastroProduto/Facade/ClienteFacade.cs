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
    public class ClienteFacade :IFacade
    {
        private readonly DataBaseContext dbContext;  

        public ClienteFacade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;            
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {
            
            ClienteDAL cd = new ClienteDAL(dbContext);
            cd.Cadastrar(entidadeDominio);

            Cliente cliente = (Cliente)entidadeDominio;
            Log classe = new Log();
            GerarLog log = new GerarLog();
            classe.Descricao = log.Processar(entidadeDominio);
            classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do cliente: " + cliente.Nome + ", " + cliente.Cpf + "]";

            LogDAL dal = new LogDAL(dbContext);
            dal.GerarLog(classe);

            return null;

        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            ClienteDAL dal = new ClienteDAL(dbContext);
            dal.Alterar(entidadeDominio);

            Cliente cliente = (Cliente)entidadeDominio;
            Log classe = new Log();
            GerarLog log = new GerarLog();
            classe.Descricao = log.Processar(entidadeDominio);
            classe.Descricao = classe.Descricao + ", [Tipo: Alteração], [Dados do cliente: " + cliente.Nome + ", " + cliente.Cpf + "]";

            LogDAL logdal = new LogDAL(dbContext);
            logdal.GerarLog(classe);
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            ClienteDAL dal = new ClienteDAL(dbContext);
            dal.Excluir(entidadeDominio);
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            List<EntidadeDominio> list = new List<EntidadeDominio>();
            ClienteDAL cd = new ClienteDAL(dbContext);            
            list = cd.Consultar(entidadeDominio);
            return list;
        }

        public Cliente ConsultarId(int id)
        {
            ClienteDAL dal = new ClienteDAL(dbContext);
            var obj=  dal.ConsultarId(id);
            return obj;
        }
    }
}
