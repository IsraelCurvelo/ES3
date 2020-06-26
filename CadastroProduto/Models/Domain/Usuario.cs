using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Usuario : EntidadeDominio
    {
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public String ConfirmacaoSenha { get; set; }

        public Usuario()
        {
        }

        public Usuario(int id, String nome, String email, String senha) : base(id)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public void CriptografarSenha()
        {

        }

        public void ValidarLogin()
        {

        }

        public void ValidarSenha()
        {

        }



    }
}
