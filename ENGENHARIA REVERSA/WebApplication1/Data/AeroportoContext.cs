using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public partial class AeroportoContext : DbContext
{
    public AeroportoContext()
    {
    }

    public AeroportoContext(DbContextOptions<AeroportoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Aeronave> Aeronaves { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Escala> Escalas { get; set; }

    public virtual DbSet<Poltrona> Poltronas { get; set; }

    public virtual DbSet<Voo> Voos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aeronave>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AERONAVE__3214EC27E1573627");

            entity.ToTable("AERONAVE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NumPoltrona).HasColumnName("NUM_POLTRONA");
            entity.Property(e => e.Tipo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TIPO");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CLIENTE__3214EC27C6DA7253");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOME");
            entity.Property(e => e.Preferencial)
                .HasDefaultValue(true)
                .HasColumnName("PREFERENCIAL");
        });

        modelBuilder.Entity<Escala>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ESCALA__3214EC27418E35CC");

            entity.ToTable("ESCALA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AeroportoSaida)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("AEROPORTO_SAIDA");
            entity.Property(e => e.IdVoo).HasColumnName("ID_VOO");

            entity.HasOne(d => d.IdVooNavigation).WithMany(p => p.Escalas)
                .HasForeignKey(d => d.IdVoo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__ESCALA__ID_VOO__3E52440B");
        });

        modelBuilder.Entity<Poltrona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__POLTRONA__3214EC274A2D9089");

            entity.ToTable("POLTRONA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdAeronave).HasColumnName("ID_AERONAVE");
            entity.Property(e => e.Localizacao)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("LOCALIZACAO");

            entity.HasOne(d => d.IdAeronaveNavigation).WithMany(p => p.Poltronas)
                .HasForeignKey(d => d.IdAeronave)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__POLTRONA__ID_AER__38996AB5");
        });

        modelBuilder.Entity<Voo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOO__3214EC27E0A8F5C7");

            entity.ToTable("VOO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.AeroportoDestino)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AEROPORTO_DESTINO");
            entity.Property(e => e.AeroportoOrigem)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AEROPORTO_ORIGEM");
            entity.Property(e => e.Disponibilidade).HasColumnName("DISPONIBILIDADE");
            entity.Property(e => e.HorarioChegada)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_CHEGADA");
            entity.Property(e => e.HorarioSaida)
                .HasColumnType("datetime")
                .HasColumnName("HORARIO_SAIDA");
            entity.Property(e => e.IdAeronave).HasColumnName("ID_AERONAVE");

            entity.HasOne(d => d.IdAeronaveNavigation).WithMany(p => p.Voos)
                .HasForeignKey(d => d.IdAeronave)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__VOO__ID_AERONAVE__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
