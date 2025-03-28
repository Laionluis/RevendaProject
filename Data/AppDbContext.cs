using Microsoft.EntityFrameworkCore;
using RevendaProject.Models;

namespace RevendaProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Revenda> Revendas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<LogTentativaEnvio> LogTentativasEnvio { get; set; }
    }

}
