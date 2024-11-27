﻿// <auto-generated />
using System;
using Aeroporto.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Aeroporto.Migrations
{
    [DbContext(typeof(AeroportoContext))]
    partial class AeroportoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Aeroporto.Models.Aeronave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("NumPoltrona")
                        .HasColumnType("int")
                        .HasColumnName("NUM_POLTRONA");

                    b.Property<string>("Tipo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TIPO");

                    b.HasKey("Id")
                        .HasName("PK__AERONAVE__3214EC27E1573627");

                    b.ToTable("AERONAVE", (string)null);
                });

            modelBuilder.Entity("Aeroporto.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("NOME");

                    b.Property<bool>("Preferencial")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true)
                        .HasColumnName("PREFERENCIAL");

                    b.HasKey("Id")
                        .HasName("PK__CLIENTE__3214EC27C6DA7253");

                    b.ToTable("CLIENTE", (string)null);
                });

            modelBuilder.Entity("Aeroporto.Models.Escala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AeroportoSaida")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("AEROPORTO_SAIDA");

                    b.Property<int?>("IdVoo")
                        .HasColumnType("int")
                        .HasColumnName("ID_VOO");

                    b.HasKey("Id")
                        .HasName("PK__ESCALA__3214EC27418E35CC");

                    b.HasIndex("IdVoo");

                    b.ToTable("ESCALA", (string)null);
                });

            modelBuilder.Entity("Aeroporto.Models.Poltrona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("IdAeronave")
                        .HasColumnType("int")
                        .HasColumnName("ID_AERONAVE");

                    b.Property<string>("Localizacao")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LOCALIZACAO");

                    b.HasKey("Id")
                        .HasName("PK__POLTRONA__3214EC274A2D9089");

                    b.HasIndex("IdAeronave");

                    b.ToTable("POLTRONA", (string)null);
                });

            modelBuilder.Entity("Aeroporto.Models.Voo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AeroportoDestino")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("AEROPORTO_DESTINO");

                    b.Property<string>("AeroportoOrigem")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("AEROPORTO_ORIGEM");

                    b.Property<int?>("Disponibilidade")
                        .HasColumnType("int")
                        .HasColumnName("DISPONIBILIDADE");

                    b.Property<DateTime?>("HorarioChegada")
                        .HasColumnType("datetime")
                        .HasColumnName("HORARIO_CHEGADA");

                    b.Property<DateTime?>("HorarioSaida")
                        .HasColumnType("datetime")
                        .HasColumnName("HORARIO_SAIDA");

                    b.Property<int?>("IdAeronave")
                        .HasColumnType("int")
                        .HasColumnName("ID_AERONAVE");

                    b.HasKey("Id")
                        .HasName("PK__VOO__3214EC27E0A8F5C7");

                    b.HasIndex("IdAeronave");

                    b.ToTable("VOO", (string)null);
                });

            modelBuilder.Entity("Aeroporto.Models.Escala", b =>
                {
                    b.HasOne("Aeroporto.Models.Voo", "IdVooNavigation")
                        .WithMany("Escalas")
                        .HasForeignKey("IdVoo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__ESCALA__ID_VOO__3E52440B");

                    b.Navigation("IdVooNavigation");
                });

            modelBuilder.Entity("Aeroporto.Models.Poltrona", b =>
                {
                    b.HasOne("Aeroporto.Models.Aeronave", "IdAeronaveNavigation")
                        .WithMany("Poltronas")
                        .HasForeignKey("IdAeronave")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__POLTRONA__ID_AER__38996AB5");

                    b.Navigation("IdAeronaveNavigation");
                });

            modelBuilder.Entity("Aeroporto.Models.Voo", b =>
                {
                    b.HasOne("Aeroporto.Models.Aeronave", "IdAeronaveNavigation")
                        .WithMany("Voos")
                        .HasForeignKey("IdAeronave")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__VOO__ID_AERONAVE__3B75D760");

                    b.Navigation("IdAeronaveNavigation");
                });

            modelBuilder.Entity("Aeroporto.Models.Aeronave", b =>
                {
                    b.Navigation("Poltronas");

                    b.Navigation("Voos");
                });

            modelBuilder.Entity("Aeroporto.Models.Voo", b =>
                {
                    b.Navigation("Escalas");
                });
#pragma warning restore 612, 618
        }
    }
}