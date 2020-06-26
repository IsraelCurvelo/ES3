using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Categoria : EntidadeDominio
    {
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
