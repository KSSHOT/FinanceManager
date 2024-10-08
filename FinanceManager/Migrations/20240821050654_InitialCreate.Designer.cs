﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinanceManager.Migrations
{
    [DbContext(typeof(FinanceDbContext))]
    [Migration("20240821050654_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FinanceManager.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Nomina"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Alimentacion"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Transporte"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Servicios"
                        },
                        new
                        {
                            Id = 5,
                            Nombre = "Entretenimiento"
                        },
                        new
                        {
                            Id = 6,
                            Nombre = "Hogar"
                        },
                        new
                        {
                            Id = 7,
                            Nombre = "Salud"
                        },
                        new
                        {
                            Id = 8,
                            Nombre = "Educacion"
                        },
                        new
                        {
                            Id = 9,
                            Nombre = "Otros"
                        });
                });

            modelBuilder.Entity("FinanceManager.Models.Finanza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Finanzas");
                });
#pragma warning restore 612, 618
        }
    }
}
