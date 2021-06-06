using CadastroProduto.Models.Domain;
using System.Collections.Generic;

namespace CadastroProduto.Models.ViewModels
{
    public class AcessorioBasicoFormViewModel
    {
        public Acessorio Acessorio { get; set; }
        
        public ICollection<Linha> Linhas { get; set; }
    }
}
