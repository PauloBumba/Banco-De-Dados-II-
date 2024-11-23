using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Fase
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public int Ordem { get; set; }

    public string? Status { get; set; }

    public int? ModalidadeId { get; set; }

    public DateOnly? DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public int? QuantidadeParticipantes { get; set; }

    public virtual ICollection<Calendario> Calendarios { get; set; } = new List<Calendario>();

    public virtual ICollection<Classificacao> Classificacaos { get; set; } = new List<Classificacao>();

    public virtual Modalidade? Modalidade { get; set; }

    public virtual ICollection<Partida> Partida { get; set; } = new List<Partida>();
}
