using CadastroProduto.Models.Domain;
using System;

namespace CadastroProduto.Strategy
{
    interface IStrategy
    {
         String Processar(EntidadeDominio entidadeDominio);
    }
}
