using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Resultado
{
    public int Id { get; set; }

    public int? PartidaId { get; set; }

    public int? EquipeId { get; set; }

    public virtual Equipe? Equipe { get; set; }

    public virtual Partida? Partida { get; set; }
}
