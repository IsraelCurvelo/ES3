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

            if (obj.Nome == null || obj.Quantidade < 0 || obj.Valor < 0  || obj.Descricao == null
                || obj.Codigo == null )
            {
                return "Erro na digitação dos dados! *Dados Obrigatórios";
            }

            return null;

        }
    }
}
