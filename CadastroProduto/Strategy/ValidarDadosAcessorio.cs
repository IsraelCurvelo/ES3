using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Strategy
{
    public class ValidarDadosAcessorio :IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            var obj = (Acessorio)entidadeDominio;

            if (obj.Nome == null || obj.Quantidade == null || obj.Valor == null || obj.Descricao == null
                || obj.Codigo == null || obj.Basico == null || obj.LinhaId == null)
            {
                return null;
            }

            return "";

        }
    }
}
