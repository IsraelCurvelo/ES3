using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Cliente : EntidadeDominio
    {
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public Endereco Endereco { get; set; }
        
        public Cliente()
        {

        }

        public Cliente(int id, string nome, string cpf, Endereco endereco) : base(id)
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
        }

        public Cliente( string nome, string cpf, Endereco endereco) 
        {
            Nome = nome;
            Cpf = cpf;
            Endereco = endereco;
        }


    }
}
