using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Strategy
{
    public class AtivarInativarProduto : IStrategy
    {
        public  String Processar(EntidadeDominio entidadeDominio)
        {
            var produto = (Produto)entidadeDominio;

            if (produto.Status)
            {
                produto.Status = false;
            }
            else
            {
                produto.Status = true;
            }

            return "";

        }
    }
}
