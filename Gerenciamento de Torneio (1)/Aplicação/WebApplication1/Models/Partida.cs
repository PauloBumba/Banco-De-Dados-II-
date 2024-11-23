using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Partida
{
    public int Id { get; set; }

    public int? FaseId { get; set; }

    public int? ModalidadeId { get; set; }

    public DateOnly? DataPartida { get; set; }

    public string? Local { get; set; }

    public int? EquipeAId { get; set; }

    public int? EquipeBId { get; set; }

    public int? ResultadoA { get; set; }

    public int? ResultadoB { get; set; }

    public int? VencedorId { get; set; }

    public bool? Empate { get; set; }

    public virtual Equipe? EquipeA { get; set; }

    public virtual Equipe? EquipeB { get; set; }

    public virtual Fase? Fase { get; set; }

    public virtual Modalidade? Modalidade { get; set; }

    public virtual ICollection<Ocorrencia> Ocorrencia { get; set; } = new List<Ocorrencia>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();

    public virtual Equipe? Vencedor { get; set; }
}
