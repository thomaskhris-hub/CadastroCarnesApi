using CadastroCarnes.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroCarnes.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(
        DbContextOptions<AppDbContext> options
    ) : base(options)
    {
    }


    public DbSet<Carne> Carnes { get; set; }

    public DbSet<Comprador> Compradores { get; set; }

    public DbSet<Cidade> Cidades { get; set; }

    public DbSet<Estado> Estados { get; set; }

    public DbSet<Pedido> Pedidos { get; set; }

    public DbSet<PedidoItem> PedidoItens { get; set; }


    protected override void OnModelCreating(
        ModelBuilder modelBuilder
    )
    {
        base.OnModelCreating(modelBuilder);


        modelBuilder.Entity<PedidoItem>()
            .HasOne(x => x.Pedido)
            .WithMany(x => x.Itens)
            .HasForeignKey(x => x.PedidoId);


        modelBuilder.Entity<PedidoItem>()
    .HasOne(x => x.Carne)
    .WithMany(x => x.PedidoItens)
    .HasForeignKey(x => x.CarneId)
    .OnDelete(DeleteBehavior.Restrict);

    modelBuilder.Entity<Pedido>()
    .HasOne(x => x.Comprador)
    .WithMany(x => x.Pedidos)
    .HasForeignKey(x => x.CompradorId)
    .OnDelete(DeleteBehavior.Restrict);


modelBuilder.Entity<PedidoItem>()
    .Property(x => x.Preco)
    .HasPrecision(18, 2);

        modelBuilder.Entity<Comprador>()
            .HasOne(x => x.Cidade)
            .WithMany()
            .HasForeignKey(x => x.CidadeId);


        modelBuilder.Entity<Cidade>()
            .HasOne(x => x.Estado)
            .WithMany(x => x.Cidades)
            .HasForeignKey(x => x.EstadoId);
    }
}