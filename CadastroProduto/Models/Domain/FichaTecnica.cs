using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class FichaTecnica : EntidadeDominio
    {
        public String Codigo { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public DateTime DataRegistro { get; set; }
        public String  Observacoes { get; set; }
        public Categoria Categoria { get; set; }
        public Componente Componente { get; set; }
      
        

        public FichaTecnica()
        {
        }

        public FichaTecnica(int id, String codigo, String nome, String descricao, Categoria categoria, Componente componente,  String observacoes): base(id)
        {
            Codigo = codigo;
            Nome = nome;
            Descricao = descricao;
            DataRegistro = DateTime.Now;
            Categoria = categoria;
            Componente = componente;
            
            Observacoes = observacoes;
        }

      

        public void ValidarDados()
        {

        }
    }
}
