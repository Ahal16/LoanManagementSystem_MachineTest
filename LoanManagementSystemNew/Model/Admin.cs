using System;
using System.Collections.Generic;

namespace LoanManagementSystemNew.Model;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
}
