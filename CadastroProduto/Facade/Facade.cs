using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Models;
using CadastroProduto.Models.Domain;
using CadastroProduto.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Fachada
{
    public class Facade : IFacade
    {
        private readonly DataBaseContext dbContext;     

        public Facade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
          
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {            
            if (entidadeDominio.GetType().Name.ToLower().Equals("usuario"))
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
                    classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do usuário: " + obj.Nome + ", " + obj.Email + "]";

                    LogDAL dal = new LogDAL(dbContext);
                    dal.GerarLog(classe);
                    return null;
                }
                return conf;

            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
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
            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
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
                    classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do produto: " + p.Nome + ", " + p.Codigo + ", " + p.DataEntrada + ", "
                        + p.Quantidade + ", " + p.Status + ", " + p.Valor + ", " + p.Cliente.Nome + ", " + p.Linha.Nome + "]";

                    LogDAL dal = new LogDAL(dbContext);
                    dal.GerarLog(classe);
                    return null;

                }

                return conf;
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
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
            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
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
            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
            {
                ValidarDadosFichaTecnica validar = new ValidarDadosFichaTecnica();
                var conf = validar.Processar(entidadeDominio);

                if (conf == null)
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
            else return null;           
        }

        public void Alterar(EntidadeDominio entidadeDominio)
        {
            if (entidadeDominio.GetType().Name.ToLower().Equals("usuario"))
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
                    classe.Descricao = classe.Descricao + ", [Tipo: Alteração], [Dados do usuário: " + obj.Nome + ", " + obj.Email + "]";
                    LogDAL dal = new LogDAL(dbContext);
                    dal.GerarLog(classe);

                }
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
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
            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
            {
                Produto p = (Produto)entidadeDominio;
                ProdutoDAL pd = new ProdutoDAL(dbContext);
                pd.Alterar(entidadeDominio);
                Log classe = new Log();
                GerarLog log = new GerarLog();
                classe.Descricao = log.Processar(entidadeDominio);
                classe.Descricao = classe.Descricao + ", [Tipo: Inserção], [Dados do produto: " + p.Nome + ", " + p.Codigo + ", " + p.DataEntrada + ", "
                    + p.Quantidade + ", " + p.Status + ", " + p.Valor + ", " + "]";

                LogDAL dal = new LogDAL(dbContext);
                dal.GerarLog(classe);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
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
            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
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
            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
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
            
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            if (entidadeDominio.GetType().Name.ToLower().Equals("usuario"))
            {
                UsuarioDAL dal = new UsuarioDAL(dbContext);
                dal.Excluir(entidadeDominio);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
            {
                ClienteDAL dal = new ClienteDAL(dbContext);
                dal.Excluir(entidadeDominio);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
            {
                ProdutoDAL dal = new ProdutoDAL(dbContext);
                dal.Excluir(entidadeDominio);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
            {
                LinhaDAL dal = new LinhaDAL(dbContext);
                dal.Excluir(entidadeDominio);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
            {
                AcessorioDAL dal = new AcessorioDAL(dbContext);
                dal.Excluir(entidadeDominio);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
            {
                FichaTecnicaDAL dal = new FichaTecnicaDAL(dbContext);
                dal.Excluir(entidadeDominio);
            }            
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {
            
            if (entidadeDominio.GetType().Name.ToLower().Equals("usuario"))
            {
                UsuarioDAL ud = new UsuarioDAL(dbContext);
                List<EntidadeDominio> list = new List<EntidadeDominio>();
                list = ud.Consultar(entidadeDominio);
                return list;
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
            {
                List<EntidadeDominio> list = new List<EntidadeDominio>();
                ClienteDAL cd = new ClienteDAL(dbContext);
                list = cd.Consultar(entidadeDominio);
                return list;
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
            {
                ProdutoDAL pd = new ProdutoDAL(dbContext);
                List<EntidadeDominio> list = new List<EntidadeDominio>();
                list = pd.Consultar(entidadeDominio);
                return list;
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
            {
                LinhaDAL ld = new LinhaDAL(dbContext);
                List<EntidadeDominio> list = new List<EntidadeDominio>();
                list = ld.Consultar(entidadeDominio);
                return list;
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
            {
                List<EntidadeDominio> list = new List<EntidadeDominio>();
                AcessorioDAL cd = new AcessorioDAL(dbContext);
                list = cd.Consultar(entidadeDominio);
                return list;
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
            {
                List<EntidadeDominio> list = new List<EntidadeDominio>();
                FichaTecnicaDAL ftd = new FichaTecnicaDAL(dbContext);
                list = ftd.Consultar(entidadeDominio);
                return list;
            }
            else return null;
        }
        
        public EntidadeDominio ConsultarId(EntidadeDominio entidadeDominio, int id)
        {
            if (entidadeDominio.GetType().Name.ToLower().Equals("usuario"))
            {
                UsuarioDAL dal = new UsuarioDAL(dbContext);
                return dal.ConsultarId(id);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
            {
                ClienteDAL dal = new ClienteDAL(dbContext);
                return dal.ConsultarId(id);                
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
            {
                ProdutoDAL dal = new ProdutoDAL(dbContext);
                return dal.ConsultarId(id);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
            {
                LinhaDAL ld = new LinhaDAL(dbContext);
                return ld.ConsultarPorId(id);               
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
            {
                AcessorioDAL dal = new AcessorioDAL(dbContext);
                return dal.ConsultarId(id);
            }
            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
            {
                FichaTecnicaDAL dal = new FichaTecnicaDAL(dbContext);
                return dal.ConsultarId(id);
            }
            else return null;
        }
        
        //REFATORAR
       
        public Linha ConsultarRemover(int id)
        {
            LinhaDAL ld = new LinhaDAL(dbContext);
            var obj = ld.ConsultarRemover(id);
            return obj;
        }
        

        public ICollection<Produto> ConsultarFiltro(Produto produto)
        {
            ProdutoDAL dal = new ProdutoDAL(dbContext);
            var prod = dal.ConsultarFiltro(produto);
            return prod;
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
