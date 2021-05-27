using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Acessorio : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Código")]
        public String Codigo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(0, 50000000, ErrorMessage = "A quantidade deve ser no mínimo {1}")]       
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Range(0, 500000000, ErrorMessage = "O valor deve ser no mínimo {1}")]
        public double  Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Básico?")]
        public bool Basico { get; set; }
        public Linha Linha { get; set; }
        [Display(Name = "Linha")]
        public int LinhaId { get; set; }

        public Acessorio()
        {
        }

        public Acessorio(string nome, string codigo, string descricao, int quantidade, double valor, bool basico)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            Quantidade = quantidade;
            Valor = valor;
            Basico = basico;
        }
    }
}
