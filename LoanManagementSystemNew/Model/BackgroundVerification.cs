using System;
using System.Collections.Generic;

namespace LoanManagementSystemNew.Model;

public partial class BackgroundVerification
{
    public int VerificationId { get; set; }

    public int LoanId { get; set; }

    public int OfficerId { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual Loan Loan { get; set; } = null!;

    public virtual LoanOfficer Officer { get; set; } = null!;
}
