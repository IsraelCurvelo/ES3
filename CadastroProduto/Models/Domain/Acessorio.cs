using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Acessorio : EntidadeDominio
    {
        public String Nome { get; set; }
        public String Codigo { get; set; }
        public String Descricao { get; set; }
        public int Quantidade { get; set; }
        public double  Valor { get; set; }
        public bool Basico { get; set; }
        public Linha Linha { get; set; }
        public int LinhaId { get; set; }

        public Acessorio()
        {
        }

        public Acessorio(string nome, string codigo, string descricao, int quantidade, double valor, bool basico)
        {
            Nome = nome;
            Codigo = codigo;
            Descricao = descricao;
            Quantidade = quantidade;
            Valor = valor;
            Basico = basico;
        }
    }
}
