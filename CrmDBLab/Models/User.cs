using System;
using System.Collections.Generic;

namespace CrmDBLab.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Email { get; set; } = null!;
}
