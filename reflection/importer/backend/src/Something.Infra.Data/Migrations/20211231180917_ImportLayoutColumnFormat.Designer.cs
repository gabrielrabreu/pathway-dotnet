﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Something.Infra.Data.Contexts;

namespace Something.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211231180917_ImportLayoutColumnFormat")]
    partial class ImportLayoutColumnFormat
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Something.Domain.Entities.Import", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<Guid>("ImportLayoutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ItemsFailedProcessed")
                        .HasColumnType("int");

                    b.Property<int>("ItemsSuccessfullyProcessed")
                        .HasColumnType("int");

                    b.Property<int>("ItemsUnprocessed")
                        .HasColumnType("int");

                    b.Property<bool>("Processed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ImportLayoutId");

                    b.ToTable("Import");
                });

            modelBuilder.Entity("Something.Domain.Entities.ImportItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Error")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImportFileLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImportId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Processed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ImportId");

                    b.ToTable("ImportItem");
                });

            modelBuilder.Entity("Something.Domain.Entities.ImportLayout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("Separator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Separator");

                    b.Property<int>("Service")
                        .HasColumnType("int")
                        .HasColumnName("Service");

                    b.HasKey("Id");

                    b.ToTable("ImportLayout");
                });

            modelBuilder.Entity("Something.Domain.Entities.ImportLayoutColumn", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Format")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ImportLayoutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ImportLayoutId");

                    b.ToTable("ImportLayoutColumn");
                });

            modelBuilder.Entity("Something.Domain.Entities.Xpto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<double>("Value")
                        .HasColumnType("float")
                        .HasColumnName("Value");

                    b.Property<int>("Version")
                        .HasColumnType("int")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.ToTable("Xpto");
                });

            modelBuilder.Entity("Something.Domain.Entities.Import", b =>
                {
                    b.HasOne("Something.Domain.Entities.ImportLayout", "ImportLayout")
                        .WithMany("Imports")
                        .HasForeignKey("ImportLayoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImportLayout");
                });

            modelBuilder.Entity("Something.Domain.Entities.ImportItem", b =>
                {
                    b.HasOne("Something.Domain.Entities.Import", "Import")
                        .WithMany("ImportItems")
                        .HasForeignKey("ImportId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Import");
                });

            modelBuilder.Entity("Something.Domain.Entities.ImportLayoutColumn", b =>
                {
                    b.HasOne("Something.Domain.Entities.ImportLayout", "ImportLayout")
                        .WithMany("Columns")
                        .HasForeignKey("ImportLayoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ImportLayout");
                });

            modelBuilder.Entity("Something.Domain.Entities.Import", b =>
                {
                    b.Navigation("ImportItems");
                });

            modelBuilder.Entity("Something.Domain.Entities.ImportLayout", b =>
                {
                    b.Navigation("Columns");

                    b.Navigation("Imports");
                });
#pragma warning restore 612, 618
        }
    }
}
