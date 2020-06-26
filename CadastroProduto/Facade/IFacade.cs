using CadastroProduto.Models.Domain;
using System.Collections.Generic;

namespace CadastroProduto.Facade
{
    public interface IFacade 
    {
        void Cadastrar(EntidadeDominio entidadeDominio);
        void Alterar(EntidadeDominio entidadeDominio);
        void Excluir(EntidadeDominio entidadeDominio);
        List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio);
    }
}
