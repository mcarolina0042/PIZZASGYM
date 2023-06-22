using Microsoft.EntityFrameworkCore;
using PIZZASG_M.Data.Models;

namespace PIZZASG_M.Data.Context
{
    public interface IMyDBContext
    {
       public DbSet<Cliente> Clientes { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}