using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Aeronave
{
    public int Id { get; set; }

    public string? Tipo { get; set; }

    public int? NumPoltrona { get; set; }

    public virtual ICollection<Poltrona> Poltronas { get; set; } = new List<Poltrona>();

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
