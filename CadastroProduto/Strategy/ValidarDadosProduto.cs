using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Strategy
{
    public class ValidarDadosProduto : IStrategy
    {
        public  String Processar(EntidadeDominio entidadeDominio)
        {
            var obj = (Produto)entidadeDominio;

            if(obj.Codigo == null || obj.DataEntrada == null || obj.Nome == null || obj.Quantidade < 0 || obj.Valor < 0 || obj.Cliente.Nome == null || obj.Cliente.Cpf == null ||
                obj.Linha.Nome == null || obj.Linha.Codigo == null || obj.Linha.FichaTecnicaLinha.Descricao == null)
            {
                return "Erro na digitação dos dados! *Dados Obrigatórios";
            }

            if (obj.FichaTecnica.Nome == null || obj.FichaTecnica.Codigo == null || obj.FichaTecnica.Descricao == null || obj.FichaTecnica.DataRegistro == null
                || obj.FichaTecnica.Categoria.Descricao == null || obj.FichaTecnica.Categoria.SubCategoria.Descricao == null
                || obj.FichaTecnica.Componente.Basico == null || obj.FichaTecnica.Componente.Primario == null || obj.FichaTecnica.Componente.Secundario == null)
            {
                return "Erro na digitação dos dados! *Dados Obrigatórios";
            }

            if (obj.Linha.Acessorio.Nome == null || obj.Linha.Acessorio.Quantidade < 0 || obj.Linha.Acessorio.Valor < 0 || obj.Linha.Acessorio.Descricao == null
                || obj.Linha.Acessorio.Codigo == null  || obj.Linha.Acessorio.LinhaId < 0)
            {
                return "Erro na digitação dos dados! *Dados Obrigatórios";
            }

            return null;

        }
    }
}
