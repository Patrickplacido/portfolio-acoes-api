﻿// <auto-generated />
using System;
using PortfolioAcoes.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace PortfolioAcoes.Infrastructure.Migrations
{
    [DbContext(typeof(AcaoDbContext))]
    partial class AcaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("PortfolioAcoes.Domain.Entities.Acao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TotalInvestido")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Acoes");
                });

            modelBuilder.Entity("PortfolioAcoes.Domain.Entities.Dividendo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("ValorDividendo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Dividendos");
                });

            modelBuilder.Entity("PortfolioAcoes.Domain.Entities.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("PrecoPorAcao")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.Property<string>("Ticker")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoTransacaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoTransacaoId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("PortfolioAcoes.Domain.Enums.TipoTransacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TipoTransacaoEnums");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Descricao = "Compra",
                            Tipo = 1
                        },
                        new
                        {
                            Id = 2,
                            Descricao = "Venda",
                            Tipo = 2
                        });
                });

            modelBuilder.Entity("PortfolioAcoes.Domain.Entities.Transacao", b =>
                {
                    b.HasOne("PortfolioAcoes.Domain.Enums.TipoTransacaoEntity", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoTransacaoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Tipo");
                });
#pragma warning restore 612, 618
        }
    }
}
