using System;
using System.Collections.Generic;

namespace CrmDBLab.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
