using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace WebApplication1.Models;

public partial class CustomDbContext : DbContext
{
    public CustomDbContext()
    {
    }

    public CustomDbContext(DbContextOptions<CustomDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atleta> Atletas { get; set; }

    public virtual DbSet<Calendario> Calendarios { get; set; }

    public virtual DbSet<Classificacao> Classificacaos { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Equipe> Equipes { get; set; }

    public virtual DbSet<Estatistica> Estatisticas { get; set; }

    public virtual DbSet<Fase> Fases { get; set; }

    public virtual DbSet<Grupo> Grupos { get; set; }

    public virtual DbSet<GrupoEquipe> GrupoEquipes { get; set; }

    public virtual DbSet<Modalidade> Modalidades { get; set; }

    public virtual DbSet<Ocorrencia> Ocorrencias { get; set; }

    public virtual DbSet<Partida> Partidas { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<Torneio> Torneios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=management;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.37-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Atleta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("atletas");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataNascimento).HasColumnName("data_nascimento");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Atleta)
                .HasForeignKey(d => d.EquipeId)
                .HasConstraintName("atletas_ibfk_1");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Atleta)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("atletas_ibfk_2");
        });

        modelBuilder.Entity<Calendario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("calendario");

            entity.HasIndex(e => e.FaseId, "fase_id");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataFim)
                .HasColumnType("datetime")
                .HasColumnName("data_fim");
            entity.Property(e => e.DataInicio)
                .HasColumnType("datetime")
                .HasColumnName("data_inicio");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.Evento)
                .HasMaxLength(100)
                .HasColumnName("evento");
            entity.Property(e => e.FaseId).HasColumnName("fase_id");
            entity.Property(e => e.Local)
                .HasMaxLength(100)
                .HasColumnName("local");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");

            entity.HasOne(d => d.Fase).WithMany(p => p.Calendarios)
                .HasForeignKey(d => d.FaseId)
                .HasConstraintName("calendario_ibfk_2");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Calendarios)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("calendario_ibfk_1");
        });

        modelBuilder.Entity<Classificacao>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("classificacao");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.FaseId, "fase_id");

            entity.HasIndex(e => e.ModalidadeId, "fk_classificacao_modalidade");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Derrotas)
                .HasDefaultValueSql("'0'")
                .HasColumnName("derrotas");
            entity.Property(e => e.Empates)
                .HasDefaultValueSql("'0'")
                .HasColumnName("empates");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.FaseId).HasColumnName("fase_id");
            entity.Property(e => e.GolsMarcados)
                .HasDefaultValueSql("'0'")
                .HasColumnName("gols_marcados");
            entity.Property(e => e.GolsSofridos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("gols_sofridos");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.OrdemClassificacao).HasColumnName("ordem_classificacao");
            entity.Property(e => e.Pontos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("pontos");
            entity.Property(e => e.SaldoDeGols)
                .HasComputedColumnSql("`gols_marcados` - `gols_sofridos`", true)
                .HasColumnName("saldo_de_gols");
            entity.Property(e => e.Vitorias)
                .HasDefaultValueSql("'0'")
                .HasColumnName("vitorias");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Classificacaos)
                .HasForeignKey(d => d.EquipeId)
                .HasConstraintName("classificacao_ibfk_3");

            entity.HasOne(d => d.Fase).WithMany(p => p.Classificacaos)
                .HasForeignKey(d => d.FaseId)
                .HasConstraintName("classificacao_ibfk_2");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Classificacaos)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("fk_classificacao_modalidade");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Equipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("equipes");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Cidade)
                .HasMaxLength(100)
                .HasColumnName("cidade");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .HasColumnName("estado");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Equipes)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("equipes_ibfk_1");
        });

        modelBuilder.Entity<Estatistica>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("estatisticas");

            entity.HasIndex(e => e.AtletaId, "atleta_id");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Assistencias)
                .HasDefaultValueSql("'0'")
                .HasColumnName("assistencias");
            entity.Property(e => e.AtletaId).HasColumnName("atleta_id");
            entity.Property(e => e.CartoesAmarelos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cartoes_amarelos");
            entity.Property(e => e.CartoesVermelhos)
                .HasDefaultValueSql("'0'")
                .HasColumnName("cartoes_vermelhos");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.Gols)
                .HasDefaultValueSql("'0'")
                .HasColumnName("gols");
            entity.Property(e => e.MinutosJogados)
                .HasDefaultValueSql("'0'")
                .HasColumnName("minutos_jogados");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.OutrosDados)
                .HasColumnType("text")
                .HasColumnName("outros_dados");

            entity.HasOne(d => d.Atleta).WithMany(p => p.Estatisticas)
                .HasForeignKey(d => d.AtletaId)
                .HasConstraintName("estatisticas_ibfk_3");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Estatisticas)
                .HasForeignKey(d => d.EquipeId)
                .HasConstraintName("estatisticas_ibfk_2");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Estatisticas)
                .HasForeignKey(d => d.ModalidadeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("estatisticas_ibfk_1");
        });

        modelBuilder.Entity<Fase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fases");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataFim).HasColumnName("data_fim");
            entity.Property(e => e.DataInicio).HasColumnName("data_inicio");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Ordem).HasColumnName("ordem");
            entity.Property(e => e.QuantidadeParticipantes).HasColumnName("quantidade_participantes");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'nao_iniciado'")
                .HasColumnType("enum('nao_iniciado','em_andamento','concluido')")
                .HasColumnName("status");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Fases)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("fases_ibfk_1");
        });

        modelBuilder.Entity<Grupo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grupos");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.QuantidadeEquipas).HasColumnName("quantidade_equipas");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'em_andamento'")
                .HasColumnType("enum('em_andamento','finalizado')")
                .HasColumnName("status");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("grupos_ibfk_1");
        });

        modelBuilder.Entity<GrupoEquipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("grupo_equipes");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.GrupoId, "grupo_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.GrupoId).HasColumnName("grupo_id");
            entity.Property(e => e.Posicao)
                .HasDefaultValueSql("'0'")
                .HasColumnName("posicao");

            entity.HasOne(d => d.Equipe).WithMany(p => p.GrupoEquipes)
                .HasForeignKey(d => d.EquipeId)
                .HasConstraintName("grupo_equipes_ibfk_2");

            entity.HasOne(d => d.Grupo).WithMany(p => p.GrupoEquipes)
                .HasForeignKey(d => d.GrupoId)
                .HasConstraintName("grupo_equipes_ibfk_1");
        });

        modelBuilder.Entity<Modalidade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("modalidades");

            entity.HasIndex(e => e.TorneioId, "torneio_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.PontosEmpate)
                .HasDefaultValueSql("'1'")
                .HasColumnName("pontos_empate");
            entity.Property(e => e.PontosVitoria)
                .HasDefaultValueSql("'3'")
                .HasColumnName("pontos_vitoria");
            entity.Property(e => e.QuantidadeJogadoresPorEquipe)
                .HasDefaultValueSql("'1'")
                .HasColumnName("quantidade_jogadores_por_equipe");
            entity.Property(e => e.QuantidadeJogadoresReserva)
                .HasDefaultValueSql("'0'")
                .HasColumnName("quantidade_jogadores_reserva");
            entity.Property(e => e.Tipo)
                .HasColumnType("enum('individual','equipe')")
                .HasColumnName("tipo");
            entity.Property(e => e.TorneioId).HasColumnName("torneio_id");

            entity.HasOne(d => d.Torneio).WithMany(p => p.Modalidades)
                .HasForeignKey(d => d.TorneioId)
                .HasConstraintName("modalidades_ibfk_1");
        });

        modelBuilder.Entity<Ocorrencia>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("ocorrencias");

            entity.HasIndex(e => e.AtletaId, "atleta_id");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.PartidaId, "partida_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AtletaId).HasColumnName("atleta_id");
            entity.Property(e => e.Descricao)
                .HasColumnType("text")
                .HasColumnName("descricao");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.MinutoOcorrencia).HasColumnName("minuto_ocorrencia");
            entity.Property(e => e.PartidaId).HasColumnName("partida_id");
            entity.Property(e => e.TipoOcorrencia)
                .HasColumnType("enum('falta','cartao_amarelo','cartao_vermelho','lesao','gol','assistencia')")
                .HasColumnName("tipo_ocorrencia");

            entity.HasOne(d => d.Atleta).WithMany(p => p.Ocorrencia)
                .HasForeignKey(d => d.AtletaId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ocorrencias_ibfk_3");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Ocorrencia)
                .HasForeignKey(d => d.EquipeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("ocorrencias_ibfk_2");

            entity.HasOne(d => d.Partida).WithMany(p => p.Ocorrencia)
                .HasForeignKey(d => d.PartidaId)
                .HasConstraintName("ocorrencias_ibfk_1");
        });

        modelBuilder.Entity<Partida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("partidas");

            entity.HasIndex(e => e.EquipeAId, "equipe_a_id");

            entity.HasIndex(e => e.EquipeBId, "equipe_b_id");

            entity.HasIndex(e => e.FaseId, "fase_id");

            entity.HasIndex(e => e.ModalidadeId, "modalidade_id");

            entity.HasIndex(e => e.VencedorId, "vencedor_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataPartida).HasColumnName("data_partida");
            entity.Property(e => e.Empate)
                .HasDefaultValueSql("'0'")
                .HasColumnName("empate");
            entity.Property(e => e.EquipeAId).HasColumnName("equipe_a_id");
            entity.Property(e => e.EquipeBId).HasColumnName("equipe_b_id");
            entity.Property(e => e.FaseId).HasColumnName("fase_id");
            entity.Property(e => e.Local)
                .HasMaxLength(100)
                .HasColumnName("local");
            entity.Property(e => e.ModalidadeId).HasColumnName("modalidade_id");
            entity.Property(e => e.ResultadoA)
                .HasDefaultValueSql("'0'")
                .HasColumnName("resultado_a");
            entity.Property(e => e.ResultadoB)
                .HasDefaultValueSql("'0'")
                .HasColumnName("resultado_b");
            entity.Property(e => e.VencedorId).HasColumnName("vencedor_id");

            entity.HasOne(d => d.EquipeA).WithMany(p => p.PartidaEquipeAs)
                .HasForeignKey(d => d.EquipeAId)
                .HasConstraintName("partidas_ibfk_3");

            entity.HasOne(d => d.EquipeB).WithMany(p => p.PartidaEquipeBs)
                .HasForeignKey(d => d.EquipeBId)
                .HasConstraintName("partidas_ibfk_4");

            entity.HasOne(d => d.Fase).WithMany(p => p.Partida)
                .HasForeignKey(d => d.FaseId)
                .HasConstraintName("partidas_ibfk_1");

            entity.HasOne(d => d.Modalidade).WithMany(p => p.Partida)
                .HasForeignKey(d => d.ModalidadeId)
                .HasConstraintName("partidas_ibfk_2");

            entity.HasOne(d => d.Vencedor).WithMany(p => p.PartidaVencedors)
                .HasForeignKey(d => d.VencedorId)
                .HasConstraintName("partidas_ibfk_5");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("resultados");

            entity.HasIndex(e => e.EquipeId, "equipe_id");

            entity.HasIndex(e => e.PartidaId, "partida_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EquipeId).HasColumnName("equipe_id");
            entity.Property(e => e.PartidaId).HasColumnName("partida_id");

            entity.HasOne(d => d.Equipe).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.EquipeId)
                .HasConstraintName("resultados_ibfk_2");

            entity.HasOne(d => d.Partida).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.PartidaId)
                .HasConstraintName("resultados_ibfk_1");
        });

        modelBuilder.Entity<Torneio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("torneios");

            entity.HasIndex(e => new { e.Nome, e.DataInicio }, "nome").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConfiguracaoEspecial)
                .HasColumnType("text")
                .HasColumnName("configuracao_especial");
            entity.Property(e => e.DataFim).HasColumnName("data_fim");
            entity.Property(e => e.DataInicio).HasColumnName("data_inicio");
            entity.Property(e => e.Nome)
                .HasMaxLength(100)
                .HasColumnName("nome");
            entity.Property(e => e.Status)
                .HasColumnType("enum('planejado','em_andamento','finalizado')")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
