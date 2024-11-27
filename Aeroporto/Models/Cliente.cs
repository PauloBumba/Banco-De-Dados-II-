using System;
using System.Collections.Generic;

namespace Aeroporto.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nome { get; set; }

    public string? Email { get; set; }

    public bool Preferencial { get; set; }
}
