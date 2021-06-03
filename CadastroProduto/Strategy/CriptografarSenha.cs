using CadastroProduto.Models.Domain;
using System;
using System.Security.Cryptography;
using System.Text;

namespace CadastroProduto.Strategy
{
    public class CriptografarSenha : IStrategy
    {      
        public String Processar(EntidadeDominio entidadeDominio)
        {
            if (!entidadeDominio.GetType().Name.Equals("usuario")) return null;
            
            Usuario usuario = (Usuario)entidadeDominio;

            // criptografia MD5
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(usuario.Senha));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++) sBuilder.Append(data[i].ToString("x2"));            

            return usuario.Senha = sBuilder.ToString();          
        }
    }       
}
