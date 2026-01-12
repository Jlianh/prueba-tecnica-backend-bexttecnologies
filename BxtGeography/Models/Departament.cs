using System;
using System.Collections.Generic;

namespace BxtGeography.Models;

public partial class Departament
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CountryId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country? Country { get; set; }
}
