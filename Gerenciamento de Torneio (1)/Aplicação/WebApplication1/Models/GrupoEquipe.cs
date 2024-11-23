using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class GrupoEquipe
{
    public int Id { get; set; }

    public int? GrupoId { get; set; }

    public int? EquipeId { get; set; }

    public int? Posicao { get; set; }

    public virtual Equipe? Equipe { get; set; }

    public virtual Grupo? Grupo { get; set; }
}
