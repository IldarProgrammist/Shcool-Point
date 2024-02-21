using System;
using System.Collections.Generic;

namespace ModelDomain.Model;

public partial class Street
{
    public int StreetId { get; set; }

    public string? StreetName { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
