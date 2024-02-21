using System;
using System.Collections.Generic;

namespace ModelDomain.Model;

public partial class Area
{
    public int AreaId { get; set; }

    public string? AreaName { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
