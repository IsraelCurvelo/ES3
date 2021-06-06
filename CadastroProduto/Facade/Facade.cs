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
        private DAL dal;

        public Facade(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
            dal = new DAL(dbContext);          
        }

        public String Cadastrar(EntidadeDominio entidadeDominio)
        {
            Log log = new Log();
            GerarLog gerarLog = new GerarLog();

            if (entidadeDominio.GetType().Name.ToLower().Equals("usuario"))
            {                
                ValidarSenha validarSenha = new ValidarSenha();
                string confirmacao = validarSenha.Processar(entidadeDominio);

                CriptografarSenha criptografarSenha = new CriptografarSenha();
                string senhacriptografada = criptografarSenha.Processar(entidadeDominio);

                Usuario usuario = (Usuario)entidadeDominio;
                usuario.Senha = senhacriptografada;
                usuario.ConfirmacaoSenha = senhacriptografada;
                
                if (confirmacao == null && senhacriptografada != null)
                {                   
                    dal.Cadastrar(usuario);                   
                    log.Descricao = gerarLog.Processar(usuario) + ", [Tipo: Inserção]";
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
            {               
                dal.Cadastrar(entidadeDominio);                             
                log.Descricao = gerarLog.Processar(entidadeDominio)+ ", [Tipo: Inserção]";                             
                dal.Cadastrar(log);
                return null;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
            {
                ValidarDadosProduto validarProduto = new ValidarDadosProduto();
                string confirmacao = validarProduto.Processar(entidadeDominio);

                if (confirmacao == null)
                {                  
                    dal.Cadastrar(entidadeDominio);                    
                    log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Inserção]";  
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
            {
                dal.Cadastrar(entidadeDominio);                              
                log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Inserção]";             
                dal.Cadastrar(log);
                return null;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
            {
                ValidarDadosAcessorio validarAcessorio = new ValidarDadosAcessorio();
                string confirmacao = validarAcessorio.Processar(entidadeDominio);
                if (confirmacao == null)
                {                    
                    dal.Cadastrar(entidadeDominio);
                    log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Inserção]";
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
            {
                ValidarDadosFichaTecnica validarFicha = new ValidarDadosFichaTecnica();
                string confirmacao = validarFicha.Processar(entidadeDominio);

                if (confirmacao == null)
                {                    
                    dal.Cadastrar(entidadeDominio);
                    log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Inserção]";                   
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }
            else return null;           
        }

        public String Alterar(EntidadeDominio entidadeDominio)
        {
            Log log = new Log();
            GerarLog gerarLog = new GerarLog();

            if (entidadeDominio.GetType().Name.ToLower().Equals("usuario"))
            {
                Usuario usuario = (Usuario)entidadeDominio;
                ValidarSenha validarSenha = new ValidarSenha();
                string confirmacao = validarSenha.Processar(entidadeDominio);

                CriptografarSenha criptografarSenha = new CriptografarSenha();
                string senhaCriptografada = criptografarSenha.Processar(entidadeDominio);

                usuario.Senha = senhaCriptografada;

                if (confirmacao == null && senhaCriptografada != null)
                {                    
                    dal.Alterar(usuario);
                    log.Descricao = gerarLog.Processar(usuario) + ", [Tipo: Alteração]";                    
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("cliente"))
            {
                dal.Alterar(entidadeDominio);
                log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Alteração]";
                dal.Cadastrar(log);
                return null;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("produto"))
            {
                ValidarDadosProduto validarProduto = new ValidarDadosProduto();
                string confirmacao = validarProduto.Processar(entidadeDominio);

                if (confirmacao == null)
                {
                    dal.Alterar(entidadeDominio);
                    log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Alteração]";
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("linha"))
            {
                dal.Alterar(entidadeDominio);
                log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Alteração]";
                dal.Cadastrar(log);
                return null;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("acessorio"))
            {
                ValidarDadosAcessorio validarAcessorio = new ValidarDadosAcessorio();
                string confirmacao = validarAcessorio.Processar(entidadeDominio);
                if (confirmacao == null)
                {
                    dal.Alterar(entidadeDominio);
                    log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Alteração]";
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }

            if (entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica"))
            {
                ValidarDadosFichaTecnica validarFicha = new ValidarDadosFichaTecnica();
                string confirmacao = validarFicha.Processar(entidadeDominio);

                if (confirmacao == null)
                {
                    dal.Alterar(entidadeDominio);
                    log.Descricao = gerarLog.Processar(entidadeDominio) + ", [Tipo: Alteração]";
                    dal.Cadastrar(log);
                    return null;
                }
                return confirmacao;
            }
            else return null;          
        }

        public void Excluir(EntidadeDominio entidadeDominio)
        {
            dal.Excluir(entidadeDominio);                       
        }

        public List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio)
        {            
            return dal.Consultar(entidadeDominio);            
        }
       
        public EntidadeDominio ConsultarId(EntidadeDominio entidadeDominio)
        {
           return dal.ConsultarId(entidadeDominio);          
        }        
            
        public Linha ConsultarRemover(int id)
        {           
            return dal.ConsultarRemoverLinha(id);           
        }        

        public ICollection<Produto> ConsultarFiltroProdutos(Produto produto)
        {           
            return dal.ConsultarFiltroProdutos(produto);            
        }       

        public Usuario ConsultarEmail(String email)
        {           
            return dal.ConsultarEmail(email);
        }

        public bool Login(EntidadeDominio entidadeDominio)
        {
            Usuario usuario = (Usuario)entidadeDominio;
            CriptografarSenha criptografar = new CriptografarSenha();
            string senhacrip = criptografar.Processar(usuario);

            usuario.Senha = senhacrip;            
            return dal.Login(usuario);            
        }

    }
}
