using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CadastroProduto.Models.Domain;
using CadastroProduto.Models;

namespace CadastroProduto.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext (DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }    

         
      
        public DbSet<Cliente> Cliente { get; set; }       
        public DbSet<FichaTecnica> FichaTecnica { get; set; }       
        public DbSet<Linha> Linha { get; set; }
        public DbSet<Produto> Produto { get; set; }       
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Acessorio> Acessorio { get; set; }
        public DbSet<Log> Log { get; set; }


    }
}
