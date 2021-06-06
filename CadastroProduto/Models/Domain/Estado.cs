using CadastroProduto.Models.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.Models
{
    public class Estado : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Estado")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O {0} tem que ter {2} digitos")]
        public String Descricao { get; set; }

        public Estado() { }
       
        public Estado(int id, String descricao) :base (id)
        {
          this.Descricao = descricao;
        }

        public Estado( String descricao) 
        {
            this.Descricao = descricao;
        }
    }
}
