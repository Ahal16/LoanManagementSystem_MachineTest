using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class CustomerFeedback
{
    public int FeedbackId { get; set; }

    public int? CustomerId { get; set; }

    public int? QuestionId { get; set; }

    public string Answer { get; set; } = null!;

    public int? Rating { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual CustomerDetail? Customer { get; set; }

    public virtual FeedbackQuestion? Question { get; set; }
}
