using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.Models.Domain
{
    public class Cliente : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "CPF")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O {0} deve conter {1}caracteres")]
        public String Cpf { get; set; }
        
        public Endereco Endereco { get; set; }
        
        public Cliente() { }
        
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
