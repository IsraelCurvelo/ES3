﻿using CadastroProduto.Models.Domain;
using System;
using System.Text.RegularExpressions;

namespace CadastroProduto.Strategy
{
    public class ValidarSenha : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            if (!entidadeDominio.GetType().Name.Equals("usuario")) return "Objeto diferente do esperado";

            Usuario usuario = (Usuario)entidadeDominio;
            
            if(usuario.Senha != usuario.ConfirmacaoSenha) return "SENHAS DIFERENTES";    
          
            var input = usuario.Senha;
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasMiniMaxChars = new Regex(@".{8,20}");            
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");


            if (!hasLowerChar.IsMatch(input) || !hasUpperChar.IsMatch(input) || !hasMiniMaxChars.IsMatch(input) 
                || !hasNumber.IsMatch(input) || !hasSymbols.IsMatch(input))            
                        return  "CARACTERES OBRIGATÓRIOS NÃO DIGITADOS" ;                              
           
            return null;            
        }
    }
}
