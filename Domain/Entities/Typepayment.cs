using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Typepayment : BaseEntity
{
    public string TypePayment1 { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
