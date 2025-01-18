using System;
using System.Collections.Generic;

namespace LMS_Machinetest6_2.Model;

public partial class HelpReport
{
    public int ReportId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
