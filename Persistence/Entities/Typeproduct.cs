using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Typeproduct
{
    public int Id { get; set; }

    public string? TypeProduct1 { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
