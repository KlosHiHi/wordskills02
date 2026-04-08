using System;
using System.Collections.Generic;

namespace ClassLibrary.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? RoleId { get; set; }
}
