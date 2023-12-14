using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typeclient : BaseEntity
{
    public string TypeClient1 { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
