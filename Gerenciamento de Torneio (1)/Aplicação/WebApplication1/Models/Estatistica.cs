using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Estatistica
{
    public int Id { get; set; }

    public int ModalidadeId { get; set; }

    public int? EquipeId { get; set; }

    public int? AtletaId { get; set; }

    public int? Gols { get; set; }

    public int? Assistencias { get; set; }

    public int? CartoesAmarelos { get; set; }

    public int? CartoesVermelhos { get; set; }

    public int? MinutosJogados { get; set; }

    public string? OutrosDados { get; set; }

    public virtual Atleta? Atleta { get; set; }

    public virtual Equipe? Equipe { get; set; }

    public virtual Modalidade Modalidade { get; set; } = null!;
}
