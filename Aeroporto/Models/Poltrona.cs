using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Poltrona
{
    public int Id { get; set; }

    public int? IdAeronave { get; set; }

    public string? Localizacao { get; set; }

    public virtual Aeronave? IdAeronaveNavigation { get; set; }
}
