using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Grupo
{
    public int Id { get; set; }

    public int? ModalidadeId { get; set; }

    public string? Nome { get; set; }

    public string? Status { get; set; }

    public int? QuantidadeEquipas { get; set; }

    public virtual ICollection<GrupoEquipe> GrupoEquipes { get; set; } = new List<GrupoEquipe>();

    public virtual Modalidade? Modalidade { get; set; }
}
