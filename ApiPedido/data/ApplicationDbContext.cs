using Microsoft.EntityFrameworkCore;
using ApiPedido.Models;

namespace ApiPedido.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Pedido> Pedidios { get; set; }
    public DbSet<DetallePedido> DetallePedidos { get; set; }
}