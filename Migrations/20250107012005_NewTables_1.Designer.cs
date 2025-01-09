﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ez_parking_api.Data;

#nullable disable

namespace ez_parking_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250107012005_NewTables_1")]
    partial class NewTables_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ez_parking_api.Models.Estacionamento", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<bool>("Cobrado")
                        .HasColumnType("bit");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumPiso")
                        .HasColumnType("int");

                    b.Property<int?>("NumVaga")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Estacionamentos", (string)null);
                });

            modelBuilder.Entity("ez_parking_api.Models.Registro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocalID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Saida")
                        .HasColumnType("datetime2");

                    b.Property<double?>("Valor")
                        .HasColumnType("float");

                    b.Property<int?>("VeiculoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LocalID");

                    b.HasIndex("VeiculoID");

                    b.ToTable("Registros", (string)null);
                });

            modelBuilder.Entity("ez_parking_api.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CPF")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ez_parking_api.Models.Veiculo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RegAtualID")
                        .HasColumnType("int");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RegAtualID");

                    b.HasIndex("UserID");

                    b.ToTable("Veiculos", (string)null);
                });

            modelBuilder.Entity("ez_parking_api.Models.Registro", b =>
                {
                    b.HasOne("ez_parking_api.Models.Estacionamento", "Local")
                        .WithMany("Historico")
                        .HasForeignKey("LocalID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ez_parking_api.Models.Veiculo", null)
                        .WithMany("Historico")
                        .HasForeignKey("VeiculoID");

                    b.Navigation("Local");
                });

            modelBuilder.Entity("ez_parking_api.Models.Veiculo", b =>
                {
                    b.HasOne("ez_parking_api.Models.Registro", "RegAtual")
                        .WithMany()
                        .HasForeignKey("RegAtualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ez_parking_api.Models.User", null)
                        .WithMany("Veiculos")
                        .HasForeignKey("UserID");

                    b.Navigation("RegAtual");
                });

            modelBuilder.Entity("ez_parking_api.Models.Estacionamento", b =>
                {
                    b.Navigation("Historico");
                });

            modelBuilder.Entity("ez_parking_api.Models.User", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("ez_parking_api.Models.Veiculo", b =>
                {
                    b.Navigation("Historico");
                });
#pragma warning restore 612, 618
        }
    }
}
