using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Linha: EntidadeDominio
    {
        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Código")]
        public String Codigo { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        public String Nome { get; set; }
        public FichaTecnicaLinha FichaTecnicaLinha { get; set; }
        public Acessorio Acessorio { get; set; }

        [NotMapped]
        public List<Acessorio> Acessorios { get; set; }


        public Linha()
        {
        }

        public Linha(int id, String codigo, String nome, FichaTecnicaLinha fichaTecnicaLinha) : base(id)
        {
            Codigo = codigo;
            Nome = nome;
            FichaTecnicaLinha = fichaTecnicaLinha;
            
        }

        
        

    }
}
