using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Endereco :EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        public String Logradouro { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Número")]
        public String Numero { get; set; }

        public String Complemento { get; set; }

        [Required(ErrorMessage = " {0} obrigatório")]
        public String Bairro { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]

        [StringLength(8, MinimumLength = 8, ErrorMessage = "O {0} deve conter {1}caracteres")]
        public String Cep { get; set; }
        public Cidade Cidade { get; set; }

        public Endereco()
        {

        }

        public Endereco( int id ,string logradouro, string numero, string complemento, string bairro, string cep, Cidade cidade) : base(id)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
        }
        public Endereco( string logradouro, string numero, string complemento, string bairro, string cep, Cidade cidade) 
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
        }


        public override String ToString()
        {
            return ""+Logradouro +", "+ Numero + ", " + Complemento + ", " + Bairro ;
        }

    }
}
