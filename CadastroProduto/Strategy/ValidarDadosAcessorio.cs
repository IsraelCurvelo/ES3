using CadastroProduto.Models.Domain;
using System;

namespace CadastroProduto.Strategy
{
    public class ValidarDadosAcessorio : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            if (!entidadeDominio.GetType().Name.ToLower().Equals("acessorio")) return "Objeto diferente do esperado";

            Acessorio acessorio = (Acessorio)entidadeDominio;

            if (acessorio.Nome == null || acessorio.Quantidade < 0 || acessorio.Valor < 0  || acessorio.Descricao == null || acessorio.Codigo == null )            
                return "Erro na digitação dos dados! *Dados Obrigatórios";         
            else
                return null;
        }
    }
}
