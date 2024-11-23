using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Torneio
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly? DataInicio { get; set; }

    public DateOnly? DataFim { get; set; }

    public string? ConfiguracaoEspecial { get; set; }

    public virtual ICollection<Modalidade> Modalidades { get; set; } = new List<Modalidade>();
}
