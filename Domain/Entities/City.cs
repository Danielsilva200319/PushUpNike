﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City : BaseEntity
{
    public string Name { get; set; }

    public int? IdDepartment { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Department IdDepartmentNavigation { get; set; }

    public virtual ICollection<Postalcode> Postalcodes { get; set; } = new List<Postalcode>();
}
