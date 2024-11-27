using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Escala
{
    public int Id { get; set; }

    public int? IdVoo { get; set; }

    public string? AeroportoSaida { get; set; }

    public virtual Voo? IdVooNavigation { get; set; }
}
