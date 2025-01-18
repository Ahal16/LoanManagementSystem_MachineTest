using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class FeedbackQuestion
{
    public int QuestionId { get; set; }

    public string Question { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<CustomerFeedback> CustomerFeedbacks { get; set; } = new List<CustomerFeedback>();
}
