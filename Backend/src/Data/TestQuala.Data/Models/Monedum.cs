using System;
using System.Collections.Generic;

namespace TestQuala.Data.Models;

public partial class Monedum
{
    public int Id { get; set; }

    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<MonedaSucursal> MonedaSucursals { get; } = new List<MonedaSucursal>();
}
