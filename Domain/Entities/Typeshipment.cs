using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typeshipment : BaseEntity
{
    public string TypeShipment1 { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
