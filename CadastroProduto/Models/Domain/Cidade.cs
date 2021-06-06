using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.Models.Domain
{
    public class Cidade : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Cidade")]
        public String Descricao { get; set; }
        public Estado Estado { get; set; }

        public Cidade(){ }

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
