using CadastroProduto.Models.Domain;
using System.Collections.Generic;

namespace CadastroProduto.Dal
{
    public interface IDAL 
    {

       void Cadastrar(EntidadeDominio entidadeDominio);

       void Alterar(EntidadeDominio entidadeDominio);

       void Excluir(EntidadeDominio entidadeDominio);

       List<EntidadeDominio> Consultar(EntidadeDominio entidadeDominio);
      
    }
}
