using CadastroProduto.Data;
using CadastroProduto.Models;
using CadastroProduto.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroProduto.Dal
{
    public class LogDAL
    {
        public readonly DataBaseContext dbContext;

        public LogDAL (DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public  void  GerarLog(Log log)
        {
            dbContext.Add(log);
            dbContext.SaveChanges();
        }

    }
}
