using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.ViewModels
{
    public class AcessorioBasicoFormViewModel
    {
        public Acessorio Acessorio { get; set; }
        public ICollection<Linha> Linhas { get; set; }
    }
}
