using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Atleta
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public DateOnly? DataNascimento { get; set; }

    public int? EquipeId { get; set; }

    public int? ModalidadeId { get; set; }

    public virtual Equipe? Equipe { get; set; }

    public virtual ICollection<Estatistica> Estatisticas { get; set; } = new List<Estatistica>();

    public virtual Modalidade? Modalidade { get; set; }

    public virtual ICollection<Ocorrencia> Ocorrencia { get; set; } = new List<Ocorrencia>();
}
