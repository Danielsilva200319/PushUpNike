﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string? Category1 { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}