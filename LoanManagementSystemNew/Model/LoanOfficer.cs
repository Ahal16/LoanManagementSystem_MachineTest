using System;
using System.Collections.Generic;

namespace LoanManagementSystemNew.Model;

public partial class LoanOfficer
{
    public int OfficerId { get; set; }

    public string FullName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContactNumber { get; set; } = null!;

    public string? Status { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
}
