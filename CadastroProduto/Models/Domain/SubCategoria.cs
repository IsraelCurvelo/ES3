using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.Models.Domain
{
    public class SubCategoria : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Sub-Categoria")]
        public String Descricao { get; set; }

        public SubCategoria() { }
        
        public SubCategoria(int id, String descricao) :base(id)
        {
            Descricao = descricao;
        }
    }
}
