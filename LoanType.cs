using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class LoanType
{
    public int LoanTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal InterestRate { get; set; }

    public decimal MinAmount { get; set; }

    public decimal MaxAmount { get; set; }

    public virtual ICollection<LoanRequest> LoanRequests { get; set; } = new List<LoanRequest>();
}
