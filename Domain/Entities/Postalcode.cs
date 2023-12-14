using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Postalcode : BaseEntity
{
    public string PostalCode1 { get; set; }

    public int? IdCity { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual City IdCityNavigation { get; set; }
}
