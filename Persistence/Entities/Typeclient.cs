using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Typeclient
{
    public int Id { get; set; }

    public string? TypeClient1 { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
