using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Categoria : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Categoria")]
        public String Descricao { get; set; }
        public SubCategoria SubCategoria { get; set; }

        public Categoria()
        {
        }

        public Categoria(int id, String descricao, SubCategoria subCategoria) : base(id)
        {
            Descricao = descricao;
            SubCategoria = subCategoria;
        }
    }
}
