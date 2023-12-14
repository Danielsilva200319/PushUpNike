using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typeorder : BaseEntity
{
    public string TypeOrder1 { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
