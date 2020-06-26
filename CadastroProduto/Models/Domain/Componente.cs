using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Componente : EntidadeDominio
    {
        public String Basico { get; set; }
        public String Primario { get; set; }
        public String Secundario{ get; set; }

        public Componente()
        {
        }

        public Componente(int id, String basico, String primario, String secundario) : base(id)
        {
            Basico = basico;
            Primario = primario;
            Secundario = secundario;
        }
    }
}
