using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.Models.Domain
{
    public class FichaTecnica : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Código")]
        public String Codigo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]       
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Data de Registro")]
        public DateTime DataRegistro { get; set; }

        [Display(Name = "Observações")]        
        public String  Observacoes { get; set; }
        public Categoria Categoria { get; set; }
        public Componente Componente { get; set; }   
      
        public FichaTecnica() { }
       
        public FichaTecnica(int id, String codigo, String nome, String descricao, Categoria categoria, Componente componente,  String observacoes): base(id)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            DataRegistro = DateTime.Now;
            Categoria = categoria;
            Componente = componente;
            
            Observacoes = observacoes;
        }
    }
}
