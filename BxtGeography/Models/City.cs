using System;
using System.Collections.Generic;

namespace BxtGeography.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? DepartamentId { get; set; }

    public virtual Departament? Departament { get; set; }
}
