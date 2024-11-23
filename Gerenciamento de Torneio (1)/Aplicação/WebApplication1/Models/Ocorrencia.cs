using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Ocorrencia
{
    public int Id { get; set; }

    public int PartidaId { get; set; }

    public int? EquipeId { get; set; }

    public int? AtletaId { get; set; }

    public string TipoOcorrencia { get; set; } = null!;

    public int? MinutoOcorrencia { get; set; }

    public string? Descricao { get; set; }

    public virtual Atleta? Atleta { get; set; }

    public virtual Equipe? Equipe { get; set; }

    public virtual Partida Partida { get; set; } = null!;
}
