using CadastroProduto.Dal;
using CadastroProduto.Data;
using CadastroProduto.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Strategy
{
    public class ValidarLogin : IStrategy
    {
        public String Processar(EntidadeDominio entidadeDominio)
        {
            var obj = (Usuario)entidadeDominio;

            CriptografarSenha crip = new CriptografarSenha();
            var s = crip.Processar(obj);

            UsuarioDAL dal = new UsuarioDAL(new DataBaseContext());
            var usuarioBanco = dal.ConsultarId(obj.Id);

            if(obj.Email != usuarioBanco.Email || obj.Senha != usuarioBanco.Senha)
            {
                return null;
            }

            return "";

        }
    }
}
