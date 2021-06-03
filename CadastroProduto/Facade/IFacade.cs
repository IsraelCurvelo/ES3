using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;

namespace CadastroProduto.Fachada
{
    public interface IFacade 
    {
        String Cadastrar(EntidadeDominio entidadeDominio);
        String Alterar(EntidadeDominio entidadeDominio);
        void Excluir(EntidadeDominio entidadeDominio);
        List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio);
    }
}
