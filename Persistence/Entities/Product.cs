using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Price { get; set; }

    public int? StockQuantity { get; set; }

    public int? IdTypeProduct { get; set; }

    public int? IdCategory { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual Typeproduct? IdTypeProductNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
