using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class SubCategoria : EntidadeDominio
    {
        public String Descricao { get; set; }

        public SubCategoria()
        {
            
        }


        public SubCategoria(int id, String descricao) :base(id)
        {
            Descricao = descricao;
        }
    }
}
