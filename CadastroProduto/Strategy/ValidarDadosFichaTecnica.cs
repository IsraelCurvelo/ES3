using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Strategy
{
    public class ValidarDadosFichaTecnica : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            var obj = (FichaTecnica)entidadeDominio;

            if(obj.Nome == null || obj.Codigo == null || obj.Descricao == null || obj.DataRegistro == null
                || obj.Categoria.Descricao == null || obj.Categoria.SubCategoria.Descricao == null
                || obj.Componente.Basico == null || obj.Componente.Primario == null || obj.Componente.Secundario == null)
            {
                return null;
            }

            return "";

        }
    }
}
