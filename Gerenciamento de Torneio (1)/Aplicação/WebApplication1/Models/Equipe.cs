using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Equipe
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int? ModalidadeId { get; set; }

    public string? Cidade { get; set; }

    public string? Estado { get; set; }

    public virtual ICollection<Atleta> Atleta { get; set; } = new List<Atleta>();

    public virtual ICollection<Classificacao> Classificacaos { get; set; } = new List<Classificacao>();

    public virtual ICollection<Estatistica> Estatisticas { get; set; } = new List<Estatistica>();

    public virtual ICollection<GrupoEquipe> GrupoEquipes { get; set; } = new List<GrupoEquipe>();

    public virtual Modalidade? Modalidade { get; set; }

    public virtual ICollection<Ocorrencia> Ocorrencia { get; set; } = new List<Ocorrencia>();

    public virtual ICollection<Partida> PartidaEquipeAs { get; set; } = new List<Partida>();

    public virtual ICollection<Partida> PartidaEquipeBs { get; set; } = new List<Partida>();

    public virtual ICollection<Partida> PartidaVencedors { get; set; } = new List<Partida>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
