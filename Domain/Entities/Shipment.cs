using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Shipment
{
    public int Id { get; set; }

    public DateOnly? ShipmentDate { get; set; }

    public DateOnly? EstimatedArrival { get; set; }

    public DateOnly? ActualArrival { get; set; }

    public int? IdAddress { get; set; }

    public int? IdStatus { get; set; }

    public int? IdTypeShipment { get; set; }

    public virtual Address IdAddressNavigation { get; set; }

    public virtual Status IdStatusNavigation { get; set; }

    public virtual Typeshipment IdTypeShipmentNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
