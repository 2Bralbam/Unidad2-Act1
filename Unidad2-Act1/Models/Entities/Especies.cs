using System;
using System.Collections.Generic;

namespace Unidad2_Act1.Models.Entities;

public partial class Especies
{
    public string Especie { get; set; } = null!;

    public int? Clase { get; set; }

    public string? Imagen { get; set; }

    public string? Orden { get; set; }

    public string? Habitat { get; set; }

    public double? Peso { get; set; }

    public int? Tamaño { get; set; }

    public bool? Oviparo { get; set; }

    public string? Observaciones { get; set; }

    public virtual Clase? ClaseNavigation { get; set; }
}
