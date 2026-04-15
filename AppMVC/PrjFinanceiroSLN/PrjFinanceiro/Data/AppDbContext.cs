
using Microsoft.EntityFrameworkCore;
using PrjFinanceiro.Models;

namespace PrjFinanceiro.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Agencia> Agencia { get; set; }

    }
}
