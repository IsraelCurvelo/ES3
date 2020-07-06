using CadastroProduto.Dal;
using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Strategy
{
    public class GerarLog  : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            return "Log Gerado";        

        }
    }
}
