using System;
using System.Collections.Generic;

namespace CrmDBLab.Models;

public partial class Street
{
    public int StreetId { get; set; }

    public string StreetName { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
