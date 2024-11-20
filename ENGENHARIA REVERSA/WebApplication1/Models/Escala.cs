using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Escala
{
    public int Id { get; set; }

    public int? IdVoo { get; set; }

    public string? AeroportoSaida { get; set; }

    public virtual Voo? IdVooNavigation { get; set; }
}
