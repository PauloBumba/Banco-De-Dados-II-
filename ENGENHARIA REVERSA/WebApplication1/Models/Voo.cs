using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Voo
{
    public int Id { get; set; }

    public string? AeroportoOrigem { get; set; }

    public string? AeroportoDestino { get; set; }

    public DateTime? HorarioSaida { get; set; }

    public DateTime? HorarioChegada { get; set; }

    public int? Disponibilidade { get; set; }

    public int? IdAeronave { get; set; }

    public virtual ICollection<Escala> Escalas { get; set; } = new List<Escala>();

    public virtual Aeronave? IdAeronaveNavigation { get; set; }
}
