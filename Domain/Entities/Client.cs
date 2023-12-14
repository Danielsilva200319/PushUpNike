using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Gender { get; set; }

    public string Comment { get; set; }

    public int? IdAddress { get; set; }

    public int? IdPhone { get; set; }

    public int? IdCity { get; set; }

    public int? IdDiscount { get; set; }

    public int? IdTypeClient { get; set; }

    public virtual Address IdAddressNavigation { get; set; }

    public virtual City IdCityNavigation { get; set; }

    public virtual Discount IdDiscountNavigation { get; set; }

    public virtual Phone IdPhoneNavigation { get; set; }

    public virtual Typeclient IdTypeClientNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
