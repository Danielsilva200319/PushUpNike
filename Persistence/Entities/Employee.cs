﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Position { get; set; }

    public string? Department { get; set; }

    public int? IdAddress { get; set; }

    public int? IdPhone { get; set; }

    public int? IdCity { get; set; }

    public virtual Address? IdAddressNavigation { get; set; }

    public virtual City? IdCityNavigation { get; set; }

    public virtual Phone? IdPhoneNavigation { get; set; }
}
