using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Produto : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Código")]
        public String Codigo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [DisplayFormat(DataFormatString = "{0:0.##}")]
        [Range(0, 500000000, ErrorMessage = "O valor deve ser no mínimo {1}")]
        public double Valor { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Data de entrada")]
        public DateTime DataEntrada { get; set; }

        
        [Display(Name="Ativo?")]
        public Boolean Status { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Range(0, 500000000, ErrorMessage = "A quantidade deve ser no mínimo {1}")]
        public int Quantidade { get; set; }
        public Cliente Cliente { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
        public Linha Linha { get; set; }
        public Produto()
        {
        }

        public Produto(int id, String codigo, String nome, Double valor, DateTime dataEntrada, bool status, int quantidade, Cliente cliente, FichaTecnica fichaTecnica): base(id)
        {
            Codigo = codigo;
            Nome = nome;
            Valor = valor;
            DataEntrada = dataEntrada;
            Status = status;
            Quantidade = quantidade;
            Cliente = cliente;
            FichaTecnica = fichaTecnica;
        }

        public void ValidarDados()
        {

        }

        public void AtivarInativarProduto()
        {

        }
    }
}
