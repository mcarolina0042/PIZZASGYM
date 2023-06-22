using Microsoft.EntityFrameworkCore;
using PIZZASG_M.Data.Models;

namespace PIZZASG_M.Data.Context
{

    public class MyDBContext : DbContext, IMyDBContext
    {
        private readonly IConfiguration confg;

        public MyDBContext(IConfiguration confg)
        {
            this.confg = confg;
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(confg.GetConnectionString("MSSQL"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
