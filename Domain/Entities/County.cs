using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class County : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
