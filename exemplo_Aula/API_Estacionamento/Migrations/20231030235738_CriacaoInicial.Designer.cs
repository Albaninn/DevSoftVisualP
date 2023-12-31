﻿// <auto-generated />
using System;
using API_Estacionamento.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_Estacionamento.Migrations
{
    [DbContext(typeof(EstacionamentoDbContext))]
    [Migration("20231030235738_CriacaoInicial")]
    partial class CriacaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("API_Estacionamento.Models.Carro", b =>
                {
                    b.Property<string>("Placa")
                        .HasColumnType("TEXT");

                    b.Property<string>("Descricao")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ModeloId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Placa");

                    b.HasIndex("ModeloId");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("API_Estacionamento.Models.Cliente", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Cpf");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("API_Estacionamento.Models.Marca", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("API_Estacionamento.Models.Modelo", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MarcaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("Modelo");
                });

            modelBuilder.Entity("CarroCliente", b =>
                {
                    b.Property<string>("CarrosPlaca")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClienteCpf")
                        .HasColumnType("TEXT");

                    b.HasKey("CarrosPlaca", "ClienteCpf");

                    b.HasIndex("ClienteCpf");

                    b.ToTable("CarroCliente");
                });

            modelBuilder.Entity("API_Estacionamento.Models.Carro", b =>
                {
                    b.HasOne("API_Estacionamento.Models.Modelo", "Modelo")
                        .WithMany()
                        .HasForeignKey("ModeloId");

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("API_Estacionamento.Models.Modelo", b =>
                {
                    b.HasOne("API_Estacionamento.Models.Marca", "Marca")
                        .WithMany()
                        .HasForeignKey("MarcaId");

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("CarroCliente", b =>
                {
                    b.HasOne("API_Estacionamento.Models.Carro", null)
                        .WithMany()
                        .HasForeignKey("CarrosPlaca")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_Estacionamento.Models.Cliente", null)
                        .WithMany()
                        .HasForeignKey("ClienteCpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
