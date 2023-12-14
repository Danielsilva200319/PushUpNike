﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Department
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? IdCountry { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual County? IdCountryNavigation { get; set; }
}
