using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
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

        public void Cadastrar(EntidadeDominio entidadeDominio)
        {
            // usuario.ValidarSenha();
            // usuario.ValidarLogin();
            // usuario.CriptografarSenha();
            ClienteDAL cd = new ClienteDAL(dbContext);
            cd.Cadastrar(entidadeDominio);
            Log.Gerar(new Dictionary<string, string>());

        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {

        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {

        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            List<EntidadeDominio> list = new List<EntidadeDominio>();
            ClienteDAL cd = new ClienteDAL(dbContext);            
            list = cd.Consultar(entidadeDominio);
            return list;
        }
    }
}
