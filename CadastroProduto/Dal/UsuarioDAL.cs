using CadastroProduto.Data;
using CadastroProduto.Data.Exception;
using CadastroProduto.Models.Domain;
using Microsoft.AspNetCore.Rewrite.Internal.UrlActions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class UsuarioDAL : DAL
    {
              
        public UsuarioDAL(DataBaseContext dbContext) : base(dbContext)
        {
           
        }       

        public Usuario ConsultarId(int id)
        {
            return dbContext.Usuario.FirstOrDefault(x => x.Id == id);
        }

        public Usuario ConsultarEmail(String email)
        {
            return dbContext.Usuario.FirstOrDefault(x => x.Email == email);
        }


        public bool Login(EntidadeDominio entidadeDominio)
        {            
            var obj = (Usuario)entidadeDominio;
            var usuarioBanco = dbContext.Usuario.FirstOrDefault(x => x.Email == obj.Email);
            if (usuarioBanco == null)
            {
                
                return false;
            }

            if (obj.Senha == usuarioBanco.Senha)
            {
                return true;
            }            
                
            return false; 
           
        }
    }
}
