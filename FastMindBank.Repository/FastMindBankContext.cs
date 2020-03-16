using FastMindBank.Model;
using Microsoft.EntityFrameworkCore;

namespace FastMindBank.Repository
{
    public class FastMindBankContext : DbContext
    {
        public FastMindBankContext()
        {

        }

        public FastMindBankContext(DbContextOptions<FastMindBankContext> options) : base(options) { }

        public DbSet<Banco> Banco { get; set; }
        public DbSet<Agencia> Agencia { get; set; }
        public DbSet<ContaCorrente> ContaCorrente { get; set; }
        public DbSet<Lancamentos> Lancamentos{ get; set; }


    }
}
