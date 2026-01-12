using System;
using System.Collections.Generic;

namespace BxtGeography.Models;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Flag { get; set; } = null!;

    public virtual ICollection<Departament> Departaments { get; set; } = new List<Departament>();
}
