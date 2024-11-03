using System;
using System.Collections.Generic;

namespace CaKoi.Entities;

public partial class FeedPlan
{
    public int FeedId { get; set; }

    public int? FishId { get; set; }

    public double? Amount { get; set; }

    public string? TimePeriod { get; set; }

    public string? GrowthStage { get; set; }

    public DateOnly? Date { get; set; }

    public virtual KoiFish? Fish { get; set; }
}
