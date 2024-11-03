using System;
using System.Collections.Generic;

namespace CaKoi.Entities;

public partial class SaltCalculation
{
    public int SaltId { get; set; }

    public int? FishTankId { get; set; }

    public double? SaltAmount { get; set; }

    public DateOnly? Date { get; set; }

    public virtual FishTank? FishTank { get; set; }
}
