using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class LoanVerification
{
    public int LoanVerificationId { get; set; }

    public int? LoanRequestId { get; set; }

    public int? OfficerId { get; set; }

    public string? Status { get; set; }

    public string? Comments { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual LoanRequest? LoanRequest { get; set; }

    public virtual LoanOfficerDetail? Officer { get; set; }
}
