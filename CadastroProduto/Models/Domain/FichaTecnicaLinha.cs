using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class FichaTecnicaLinha : EntidadeDominio
    {
        public String Descricao { get; set; }

        public FichaTecnicaLinha()
        {
        }

        public FichaTecnicaLinha(int id, string descricao): base(id)
        {
            Descricao = descricao;
        }
    }
}
