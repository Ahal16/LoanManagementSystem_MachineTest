using System;
using System.Collections.Generic;

namespace LoanManagementSystemNew.Model;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int CustomerId { get; set; }

    public string FeedbackText { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
