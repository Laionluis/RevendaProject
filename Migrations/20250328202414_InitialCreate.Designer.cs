﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RevendaProject.Data;

#nullable disable

namespace RevendaProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250328202414_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("RevendaProject.Models.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Principal")
                        .HasColumnType("boolean");

                    b.Property<int>("RevendaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RevendaId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("RevendaProject.Models.EnderecoEntrega", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RevendaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RevendaId");

                    b.ToTable("EnderecosEntrega");
                });

            modelBuilder.Entity("RevendaProject.Models.ItemPedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<string>("Produto")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.ToTable("ItensPedido");
                });

            modelBuilder.Entity("RevendaProject.Models.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ClienteIdentificador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("RevendaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RevendaId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("RevendaProject.Models.Revenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeFantasia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Revendas");
                });

            modelBuilder.Entity("RevendaProject.Models.Telefone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("RevendaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RevendaId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("RevendaProject.Models.Contato", b =>
                {
                    b.HasOne("RevendaProject.Models.Revenda", "Revenda")
                        .WithMany("Contatos")
                        .HasForeignKey("RevendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("RevendaProject.Models.EnderecoEntrega", b =>
                {
                    b.HasOne("RevendaProject.Models.Revenda", "Revenda")
                        .WithMany("EnderecosEntrega")
                        .HasForeignKey("RevendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("RevendaProject.Models.ItemPedido", b =>
                {
                    b.HasOne("RevendaProject.Models.Pedido", "Pedido")
                        .WithMany("Itens")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("RevendaProject.Models.Pedido", b =>
                {
                    b.HasOne("RevendaProject.Models.Revenda", "Revenda")
                        .WithMany()
                        .HasForeignKey("RevendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("RevendaProject.Models.Telefone", b =>
                {
                    b.HasOne("RevendaProject.Models.Revenda", "Revenda")
                        .WithMany("Telefones")
                        .HasForeignKey("RevendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Revenda");
                });

            modelBuilder.Entity("RevendaProject.Models.Pedido", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("RevendaProject.Models.Revenda", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("EnderecosEntrega");

                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
