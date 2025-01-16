using System;
using System.Collections.Generic;

namespace LoanManagementSystemNew.Model;

public partial class Loan
{
    public int LoanId { get; set; }

    public int CustomerId { get; set; }

    public string LoanType { get; set; } = null!;

    public decimal Amount { get; set; }

    public int DurationInMonths { get; set; }

    public decimal InterestRate { get; set; }

    public string? Status { get; set; }

    public int? AssignedOfficerId { get; set; }

    public string? VerificationNotes { get; set; }

    public virtual LoanOfficer? AssignedOfficer { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual Customer Customer { get; set; } = null!;
}
