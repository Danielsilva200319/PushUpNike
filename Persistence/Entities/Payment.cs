using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int? Amount { get; set; }

    public DateOnly? PaymentDate { get; set; }

    public int? IdClient { get; set; }

    public int? IdTypePayment { get; set; }

    public int? IdStatus { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual Typepayment? IdTypePaymentNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
