using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Models
{
    public class Log
    {
		private String descricao;

		public static void Gerar(Dictionary<String, String> atributos)
		{
			
		}

		public String getDescricao()
		{
			return descricao;
		}

		public void setDescricao(String descricao)
		{
			this.descricao = descricao;
		}
	}
}
