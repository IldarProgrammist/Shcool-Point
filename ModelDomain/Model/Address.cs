using System;
using System.Collections.Generic;

namespace ModelDomain.Model;

public partial class Address
{
    public int AddressId { get; set; }

    public string? Building { get; set; }

    public string? Construction { get; set; }

    public int? CityId { get; set; }

    public int? AreaId { get; set; }

    public int? StreetId { get; set; }

    public virtual Area? Area { get; set; }

    public virtual City? City { get; set; }

    public virtual Street? Street { get; set; }
}
