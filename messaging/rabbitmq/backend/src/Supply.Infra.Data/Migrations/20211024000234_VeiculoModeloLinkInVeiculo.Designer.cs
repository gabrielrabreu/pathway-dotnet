﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Supply.Infra.Data.Context;

namespace Supply.Infra.Data.Migrations
{
    [DbContext(typeof(SupplyDataContext))]
    [Migration("20211024000234_VeiculoModeloLinkInVeiculo")]
    partial class VeiculoModeloLinkInVeiculo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Supply.Domain.Entities.Veiculo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Placa");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit")
                        .HasColumnName("Removed");

                    b.Property<Guid>("VeiculoModeloId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoModeloId");

                    b.ToTable("Veiculo");
                });

            modelBuilder.Entity("Supply.Domain.Entities.VeiculoMarca", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit")
                        .HasColumnName("Removed");

                    b.HasKey("Id");

                    b.ToTable("VeiculoMarca");
                });

            modelBuilder.Entity("Supply.Domain.Entities.VeiculoModelo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<bool>("Removed")
                        .HasColumnType("bit")
                        .HasColumnName("Removed");

                    b.Property<Guid>("VeiculoMarcaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VeiculoMarcaId");

                    b.ToTable("VeiculoModelo");
                });

            modelBuilder.Entity("Supply.Domain.Entities.Veiculo", b =>
                {
                    b.HasOne("Supply.Domain.Entities.VeiculoModelo", "VeiculoModelo")
                        .WithMany("Veiculos")
                        .HasForeignKey("VeiculoModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VeiculoModelo");
                });

            modelBuilder.Entity("Supply.Domain.Entities.VeiculoModelo", b =>
                {
                    b.HasOne("Supply.Domain.Entities.VeiculoMarca", "VeiculoMarca")
                        .WithMany("VeiculoModelos")
                        .HasForeignKey("VeiculoMarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("VeiculoMarca");
                });

            modelBuilder.Entity("Supply.Domain.Entities.VeiculoMarca", b =>
                {
                    b.Navigation("VeiculoModelos");
                });

            modelBuilder.Entity("Supply.Domain.Entities.VeiculoModelo", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
