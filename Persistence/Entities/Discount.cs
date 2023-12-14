using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Discount
{
    public int Id { get; set; }

    public string? Discount1 { get; set; }

    public string? Description { get; set; }

    public double? Percentage { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? IdStatus { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual Status? IdStatusNavigation { get; set; }
}
