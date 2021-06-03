using CadastroProduto.Models.Domain;
using System;

namespace CadastroProduto.Strategy
{
    public class ValidarDadosProduto : IStrategy
    {
        public  String Processar(EntidadeDominio entidadeDominio)
        {
            if (!entidadeDominio.GetType().Name.ToLower().Equals("produto")) return "Objeto diferente do esperado";

            Produto produto = (Produto)entidadeDominio;

            if(produto.Codigo == null || produto.DataEntrada == null || produto.Nome == null || produto.Quantidade < 0 || produto.Valor < 0 || produto.Cliente.Nome == null || produto.Cliente.Cpf == null ||
                produto.Linha.Nome == null || produto.Linha.Codigo == null || produto.Linha.FichaTecnicaLinha.Descricao == null)     
                        return "Erro na digitação dos dados! *Dados Obrigatórios";
            

            if (produto.FichaTecnica.Nome == null || produto.FichaTecnica.Codigo == null || produto.FichaTecnica.Descricao == null || produto.FichaTecnica.DataRegistro == null
                || produto.FichaTecnica.Categoria.Descricao == null || produto.FichaTecnica.Categoria.SubCategoria.Descricao == null
                || produto.FichaTecnica.Componente.Basico == null || produto.FichaTecnica.Componente.Primario == null || produto.FichaTecnica.Componente.Secundario == null)
                        return "Erro na digitação dos dados! *Dados Obrigatórios";
           

            if (produto.Linha.Acessorio.Nome == null || produto.Linha.Acessorio.Quantidade < 0 || produto.Linha.Acessorio.Valor < 0 || produto.Linha.Acessorio.Descricao == null
                || produto.Linha.Acessorio.Codigo == null  || produto.Linha.Acessorio.LinhaId < 0)  
                        return "Erro na digitação dos dados! *Dados Obrigatórios";            

            return null;
        }
    }
}
