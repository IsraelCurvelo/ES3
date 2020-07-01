using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Data.Exception
{
    public class DbException : ApplicationException
    {
        public DbException(string message) : base(message)
        {

        }
    }
}
