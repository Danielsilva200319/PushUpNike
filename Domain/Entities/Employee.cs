using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Employee : BaseEntity
{
    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Position { get; set; }

    public string Department { get; set; }

    public int? IdAddress { get; set; }

    public int? IdPhone { get; set; }

    public int? IdCity { get; set; }

    public virtual Address IdAddressNavigation { get; set; }

    public virtual City IdCityNavigation { get; set; }

    public virtual Phone IdPhoneNavigation { get; set; }
}
