using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typeproduct : BaseEntity
{
    public string TypeProduct1 { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
