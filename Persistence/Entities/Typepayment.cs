using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Typepayment
{
    public int Id { get; set; }

    public string? TypePayment1 { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
