using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Address : BaseEntity
{
    public string Address1 { get; set; }

    public int? IdPostalCode { get; set; }

    public int? IdCity { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual City IdCityNavigation { get; set; }

    public virtual Postalcode IdPostalCodeNavigation { get; set; }

    public virtual ICollection<Shipment> Shipments { get; set; } = new List<Shipment>();
}
