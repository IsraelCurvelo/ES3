using CadastroProduto.Models.Domain;
using System;

namespace CadastroProduto.Strategy
{
    public class ValidarDadosFichaTecnica : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            if (!entidadeDominio.GetType().Name.ToLower().Equals("fichatecnica")) return "Objeto diferente do esperado";

            FichaTecnica fichaTecnica = (FichaTecnica)entidadeDominio;

            if(fichaTecnica.Nome == null || fichaTecnica.Codigo == null || fichaTecnica.Descricao == null || fichaTecnica.DataRegistro == null
                || fichaTecnica.Categoria.Descricao == null || fichaTecnica.Categoria.SubCategoria.Descricao == null
                || fichaTecnica.Componente.Basico == null || fichaTecnica.Componente.Primario == null || fichaTecnica.Componente.Secundario == null)
                            return "Erro nos dados digitados, * Campos obrigatório!";
            else 
                return null;
        }
    }
}
