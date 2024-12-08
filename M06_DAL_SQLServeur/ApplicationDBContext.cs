using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M06_DAL_SQLServeur
{
    public  class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions options)
        : base(options)
        {
            ;
        }

        public DbSet<CompteBancaireSQLSeveurDTO> CompteBancaires { get; set; }
        public DbSet<TransactionSQLServeurDTO> Transactions  { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CompteBancaireSQLSeveurDTO>()
                .HasKey(c => c.CompteBancaireId);
            modelBuilder.Entity<TransactionSQLServeurDTO>()
                .HasKey(c => c.TransactionId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
