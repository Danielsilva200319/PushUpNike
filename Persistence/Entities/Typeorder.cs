using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Typeorder
{
    public int Id { get; set; }

    public string? TypeOrder1 { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
