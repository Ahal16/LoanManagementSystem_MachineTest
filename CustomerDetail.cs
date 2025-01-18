using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class CustomerDetail
{
    public int CustomerId { get; set; }

    public int? UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public decimal AnnualIncome { get; set; }

    public virtual ICollection<CustomerFeedback> CustomerFeedbacks { get; set; } = new List<CustomerFeedback>();

    public virtual ICollection<LoanRequest> LoanRequests { get; set; } = new List<LoanRequest>();

    public virtual User? User { get; set; }
}
