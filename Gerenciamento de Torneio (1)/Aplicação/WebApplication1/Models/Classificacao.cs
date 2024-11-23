using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Classificacao
{
    public int Id { get; set; }

    public int? FaseId { get; set; }

    public int? EquipeId { get; set; }

    public int? Pontos { get; set; }

    public int? Vitorias { get; set; }

    public int? Empates { get; set; }

    public int? Derrotas { get; set; }

    public int? GolsMarcados { get; set; }

    public int? GolsSofridos { get; set; }

    public int? SaldoDeGols { get; set; }

    public int? OrdemClassificacao { get; set; }

    public int? ModalidadeId { get; set; }

    public virtual Equipe? Equipe { get; set; }

    public virtual Fase? Fase { get; set; }

    public virtual Modalidade? Modalidade { get; set; }
}
