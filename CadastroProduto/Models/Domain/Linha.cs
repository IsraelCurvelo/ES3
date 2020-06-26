using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Linha: EntidadeDominio
    {
        public String Codigo { get; set; }
        public String Nome { get; set; }
        public FichaTecnicaLinha FichaTecnicaLinha { get; set; }
        public Acessorio Acessorio { get; set; }
       



        public Linha()
        {
        }

        public Linha(int id, String codigo, String nome, FichaTecnicaLinha fichaTecnicaLinha) : base(id)
        {
            Codigo = codigo;
            Nome = nome;
            FichaTecnicaLinha = fichaTecnicaLinha;
            
        }

        
        

    }
}
