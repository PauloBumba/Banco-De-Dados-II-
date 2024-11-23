using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Modalidade
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public int? PontosVitoria { get; set; }

    public int? PontosEmpate { get; set; }

    public int? QuantidadeJogadoresPorEquipe { get; set; }

    public int? QuantidadeJogadoresReserva { get; set; }

    public int? TorneioId { get; set; }

    public virtual ICollection<Atleta> Atleta { get; set; } = new List<Atleta>();

    public virtual ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();

    public virtual ICollection<Classificacao> Classificacaos { get; set; } = new List<Classificacao>();

    public virtual ICollection<Equipe> Equipes { get; set; } = new List<Equipe>();

    public virtual ICollection<Estatistica> Estatisticas { get; set; } = new List<Estatistica>();

    public virtual ICollection<Fase> Fases { get; set; } = new List<Fase>();

    public virtual ICollection<Grupo> Grupos { get; set; } = new List<Grupo>();

    public virtual ICollection<Partida> Partida { get; set; } = new List<Partida>();

    public virtual Torneio? Torneio { get; set; }
}
