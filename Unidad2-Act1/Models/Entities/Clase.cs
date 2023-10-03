using System;
using System.Collections.Generic;

namespace Unidad2_Act1.Models.Entities;

public partial class Clase
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Especies> Especies { get; set; } = new List<Especies>();
}
