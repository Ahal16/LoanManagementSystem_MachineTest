using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class LoanOfficerDetail
{
    public int OfficerId { get; set; }

    public int? UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Department { get; set; } = null!;

    public string BadgeNumber { get; set; } = null!;

    public virtual ICollection<BackgroundVerification> BackgroundVerifications { get; set; } = new List<BackgroundVerification>();

    public virtual ICollection<LoanVerification> LoanVerifications { get; set; } = new List<LoanVerification>();

    public virtual User? User { get; set; }
}
