using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Cidade : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Cidade")]
        public String Descricao { get; set; }
        public Estado Estado { get; set; }

        public Cidade()
        {

        }

        public Cidade(int id, String descricao,Estado estado): base(id)
        {
            Descricao = descricao;
            Estado = estado;
        }

        public Cidade( String descricao, Estado estado) 
        {
            Descricao = descricao;
            Estado = estado;
        }


    }
}
