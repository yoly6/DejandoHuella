using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Carrito_de_compras.Models;

namespace Carrito_de_compras.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Categoria> Categoria { get; set; }

    public DbSet<Cliente> Cliente { get; set; }

    public DbSet<Factura> Factura { get; set; }

    public DbSet<Producto> Producto { get; set; }

    public DbSet<Pago> Pago { get; set; }

    public DbSet<ModoPago> ModoPago { get; set; }
    public DbSet<Detalle> Detalle { get; set; }
}
}
