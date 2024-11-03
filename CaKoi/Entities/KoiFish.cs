using System;
using System.Collections.Generic;

namespace CaKoi.Entities;

public partial class KoiFish
{
    public int FishId { get; set; }

    public string Name { get; set; } = null!;

    public string? Gender { get; set; }

    public string? Species { get; set; }

    public string? Origin { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public double? Weight { get; set; }

    public double? Length { get; set; }

    public int? FishTankId { get; set; }

    public int? OwnerId { get; set; }

    public virtual ICollection<FeedPlan> FeedPlans { get; set; } = new List<FeedPlan>();

    public virtual FishTank? FishTank { get; set; }

    public virtual User? Owner { get; set; }
}
