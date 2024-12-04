using PortfolioAcoes.Domain.Entities;
using PortfolioAcoes.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace PortfolioAcoes.Infrastructure
{
    public class AcaoDbContext : DbContext
    {
        public AcaoDbContext(DbContextOptions<AcaoDbContext> options) : base(options)
        {
        }

        public DbSet<Acao> Acoes { get; set; } = null!;
        public DbSet<Transacao> Transacoes { get; set; } = null!;
        public DbSet<Dividendo> Dividendos { get; set; } = null!;
        public DbSet<TipoTransacaoEntity> TipoTransacaoEnums { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.TotalInvestido).HasColumnType("decimal(18,2)");
                entity.Property(e => e.UserId).IsRequired();
            });

            modelBuilder.Entity<Transacao>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.PrecoPorAcao).HasColumnType("decimal(18,2)");
                entity.HasOne(e => e.Tipo)
                      .WithMany()
                      .HasForeignKey(e => e.TipoTransacaoId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<TipoTransacaoEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Descricao).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Tipo).HasColumnType("int");
            });

            modelBuilder.Entity<Dividendo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.ValorDividendo).HasColumnType("decimal(18,2)");
            });

            // Data Seeding
            modelBuilder.Entity<TipoTransacaoEntity>().HasData(
                new TipoTransacaoEntity { Id = (int)TipoTransacaoEnum.Compra, Descricao = "Compra", Tipo = TipoTransacaoEnum.Compra },
                new TipoTransacaoEntity { Id = (int)TipoTransacaoEnum.Venda, Descricao = "Venda", Tipo = TipoTransacaoEnum.Venda }
            );
        }
    }
}