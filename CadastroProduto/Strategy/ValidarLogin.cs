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
            if (!entidadeDominio.GetType().Name.Equals("usuario")) return "Objeto diferente do esperado";

            Usuario usuario = (Usuario)entidadeDominio;

            CriptografarSenha criptografarSenha = new CriptografarSenha();
            string confirmacao = criptografarSenha.Processar(usuario);


            //REFATORAR *********************************************************
            UsuarioDAL dal = new UsuarioDAL(new DataBaseContext());
            Usuario usuarioBanco = dal.ConsultarId(usuario.Id);

            if(usuario.Email != usuarioBanco.Email || usuario.Senha != usuarioBanco.Senha) return null;          
            else return "";
        }
    }
}
