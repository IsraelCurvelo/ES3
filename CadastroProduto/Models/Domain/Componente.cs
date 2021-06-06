using System;
using System.ComponentModel.DataAnnotations;

namespace CadastroProduto.Models.Domain
{
    public class Componente : EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Componente básico")]
        public String Basico { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Componente primario")]
        public String Primario { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Componente secundario")]
        public String Secundario { get; set; }

        public Componente() { }

        public Componente(int id, String basico, String primario, String secundario) : base(id)
        {
            Basico = basico;
            Primario = primario;
            Secundario = secundario;
        }
    }
}
