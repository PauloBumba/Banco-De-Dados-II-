using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Calendario
{
    public int Id { get; set; }

    public string Evento { get; set; } = null!;

    public string? Descricao { get; set; }

    public DateTime DataInicio { get; set; }

    public DateTime DataFim { get; set; }

    public string? Local { get; set; }

    public int? ModalidadeId { get; set; }

    public int? FaseId { get; set; }

    public virtual Fase? Fase { get; set; }

    public virtual Modalidade? Modalidade { get; set; }
}
