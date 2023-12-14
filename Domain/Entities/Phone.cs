using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Phone : BaseEntity
{
    public string Phone1 { get; set; }

    public string TypePhone { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
