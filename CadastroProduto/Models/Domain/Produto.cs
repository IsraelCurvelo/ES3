using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models.Domain
{
    public class Produto : EntidadeDominio
    {
        public String Codigo { get; set; }
        public String Nome { get; set; }
        public double Valor { get; set; }
        public DateTime DataEntrada { get; set; }
        public Boolean Status { get; set; }
        public int Quantidade { get; set; }
        public Cliente Cliente { get; set; }
        public FichaTecnica FichaTecnica { get; set; }
        public Linha Linha { get; set; }
        public Produto()
        {
        }

        public Produto(int id, String codigo, String nome, Double valor, DateTime dataEntrada, bool status, int quantidade, Cliente cliente, FichaTecnica fichaTecnica): base(id)
        {
            Codigo = codigo;
            Nome = nome;
            Valor = valor;
            DataEntrada = dataEntrada;
            Status = status;
            Quantidade = quantidade;
            Cliente = cliente;
            FichaTecnica = fichaTecnica;
        }

        public void ValidarDados()
        {

        }

        public void AtivarInativarProduto()
        {

        }
    }
}
