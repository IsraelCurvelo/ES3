using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models
{
    public class Estado : EntidadeDominio
    {
        public String Descricao { get; set; }

        public Estado()
        {

        }

        public Estado(int id, String descricao) :base (id)
        {
          this.Descricao = descricao;
        }

        public Estado( String descricao) 
        {
            this.Descricao = descricao;
        }
    }
}
