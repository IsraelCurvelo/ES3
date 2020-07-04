using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Strategy
{
    interface IStrategy
    {
         String Processar(EntidadeDominio entidadeDominio);
    }
}
