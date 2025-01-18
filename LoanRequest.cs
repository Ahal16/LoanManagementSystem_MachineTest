using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class LoanRequest
{
    public int LoanRequestId { get; set; }

    public int? CustomerId { get; set; }

    public int? LoanTypeId { get; set; }

    public decimal Amount { get; set; }

    public int Duration { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual CustomerDetail? Customer { get; set; }

    public virtual LoanType? LoanType { get; set; }

    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();
}
