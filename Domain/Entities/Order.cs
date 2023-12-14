using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Order
{
    public int Id { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? TotalAmount { get; set; }

    public int? IdClient { get; set; }

    public int? IdTypeOrder { get; set; }

    public int? IdShipment { get; set; }

    public int? IdPayment { get; set; }

    public int? IdStatus { get; set; }

    public int? IdProduct { get; set; }

    public virtual Client IdClientNavigation { get; set; }

    public virtual Payment IdPaymentNavigation { get; set; }

    public virtual Product IdProductNavigation { get; set; }

    public virtual Shipment IdShipmentNavigation { get; set; }

    public virtual Status IdStatusNavigation { get; set; }

    public virtual Typeorder IdTypeOrderNavigation { get; set; }
}
