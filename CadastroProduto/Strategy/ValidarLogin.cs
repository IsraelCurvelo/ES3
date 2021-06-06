using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Models.Domain;
using System;

namespace CadastroProduto.Strategy
{
    public class ValidarLogin : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            if (!entidadeDominio.GetType().Name.Equals("usuario")) return null;

            Usuario usuario = (Usuario)entidadeDominio;

            CriptografarSenha criptografarSenha = new CriptografarSenha();
            string confirmacao = criptografarSenha.Processar(usuario);

            DAL dal = new DAL(new DataBaseContext());
            Usuario usuarioBanco = (Usuario)dal.ConsultarId(usuario);

            if(usuario.Email != usuarioBanco.Email || usuario.Senha != usuarioBanco.Senha) return null;          
            else return "Ok";
        }
    }
}
