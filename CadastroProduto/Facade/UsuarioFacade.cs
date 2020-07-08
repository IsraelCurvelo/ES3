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
    public class UsuarioFacade :IFacade
    {
       private readonly DataBaseContext dbContext;
        
        public UsuarioFacade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;           
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {
            var obj = (Usuario)entidadeDominio;
            ValidarSenha vs = new ValidarSenha();
            var conf = vs.Processar(entidadeDominio);

            CriptografarSenha crip = new CriptografarSenha();
            var senhacrip = crip.Processar(entidadeDominio);

            obj.Senha = senhacrip;

            if (conf == null && senhacrip != null)
            {
                UsuarioDAL ud = new UsuarioDAL(dbContext);
                ud.Cadastrar(obj);

                Log classe = new Log();
                GerarLog log = new GerarLog();
                classe.Descricao = log.Processar(obj);
                classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do usuário: " + obj.Nome + ", " + obj.Email+"]";

                LogDAL dal = new LogDAL(dbContext);
                dal.GerarLog(classe);
                return null;
            }
            return conf;

        }

        public void Alterar (EntidadeDominio entidadeDominio)
        {

            var obj = (Usuario)entidadeDominio;
            ValidarSenha vs = new ValidarSenha();
            var conf = vs.Processar(entidadeDominio);

            CriptografarSenha crip = new CriptografarSenha();
            var senhacrip = crip.Processar(entidadeDominio);

            obj.Senha = senhacrip;

            if (conf == null && senhacrip != null)
            {
                UsuarioDAL ud = new UsuarioDAL(dbContext);
                ud.Alterar(obj);

                Log classe = new Log();
                GerarLog log = new GerarLog();
                classe.Descricao = log.Processar(obj);
                classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do usuário: " + obj.Nome + ", " + obj.Email + "]";

                LogDAL dal = new LogDAL(dbContext);
                dal.GerarLog(classe);
                
            }            
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            UsuarioDAL dal = new UsuarioDAL(dbContext);
            dal.Excluir(entidadeDominio);
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            UsuarioDAL ud = new UsuarioDAL(dbContext);

            List<EntidadeDominio> list = new List<EntidadeDominio>();
            list=ud.Consultar(entidadeDominio);
            return list;
        }

        public Usuario ConsultarId(int id)
        {
            UsuarioDAL dal = new UsuarioDAL(dbContext);
            return dal.ConsultarId(id);
        }

        public Usuario ConsultarEmail(String email)
        {
            UsuarioDAL dal = new UsuarioDAL(dbContext);
            return dal.ConsultarEmail(email);
        }

        public bool Login(EntidadeDominio entidadeDominio)
        {
            var obj = (Usuario)entidadeDominio;
            CriptografarSenha crip = new CriptografarSenha();
            var senhacrip = crip.Processar(entidadeDominio);

            obj.Senha = senhacrip;

            UsuarioDAL dal = new UsuarioDAL(dbContext);
            var conf = dal.Login(obj);
            return conf;
        }

    }
}
