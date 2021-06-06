using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.Models.Domain
{
    public class FichaTecnicaLinha : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        public FichaTecnicaLinha() { }       

        public FichaTecnicaLinha(int id, string descricao): base(id)
        {
            Descricao = descricao;
        }
    }
}
