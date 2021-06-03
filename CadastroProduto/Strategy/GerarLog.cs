using CadastroProduto.Models.Domain;
using System;

namespace CadastroProduto.Strategy
{
    public class GerarLog : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            switch (entidadeDominio.GetType().Name.ToLower())
            {
                case ("usuario"):
                    Usuario usuario = (Usuario)entidadeDominio;
                    return "Log Gerado!: [Data: " + DateTime.Now + "], [Dados do usuário: " + usuario.Nome + ", " + usuario.Email + "]";
                
                case ("acessorio"):
                    Acessorio acessorio = (Acessorio)entidadeDominio;
                    return "Log Gerado!: [Data: " + DateTime.Now + "], [Dados do acessório: " + acessorio.Nome + ", " + acessorio.Codigo + "]";

                case ("cliente"):
                    Cliente cliente = (Cliente)entidadeDominio;
                    return "Log Gerado!: [Data: " + DateTime.Now + "], [Dados do cliente: " + cliente.Nome + ", " + cliente.Cpf + "]";                

                case ("linha"):
                    Linha linha = (Linha)entidadeDominio;
                    return "Log Gerado!: [Data: " + DateTime.Now + "], [Dados da linha: " + linha.Nome + ", " + linha.Codigo + "]";

                case ("fichatecnica"):
                    FichaTecnica fichaTecnica = (FichaTecnica)entidadeDominio;
                    return "Log Gerado!: [Data: " + DateTime.Now + "], , [Dados da Ficha Técnica: " + fichaTecnica.Nome + ", " + fichaTecnica.Codigo + "] ";

                case ("produto"):
                    Produto produto = (Produto)entidadeDominio;
                    return "Log Gerado!: [Data: " + DateTime.Now + "], , [Dados do produto: " + produto.Nome + ", " + produto.Codigo + ", " + produto.DataEntrada + ", "
                        + produto.Quantidade + ", " + produto.Status + ", " + produto.Valor + ", " + produto.Cliente.Nome + ", " + produto.Linha.Nome + "]";

                default:
                    return null;
            } 
        }
    }
}
