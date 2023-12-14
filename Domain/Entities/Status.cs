using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Status : BaseEntity
{
    public string EntityName { get; set; }

    public string Status1 { get; set; }

    public string Description { get; set; }

    public virtual ICollection<Discount> Discounts { get; set; } = new List<Discount>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
