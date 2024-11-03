using System;
using System.Collections.Generic;

namespace CaKoi.Entities;

public partial class WaterQuality
{
    public int WaterId { get; set; }

    public int? FishTankId { get; set; }

    public double? Temperature { get; set; }

    public double? PH { get; set; }

    public double? O2 { get; set; }

    public double? No2 { get; set; }

    public double? No3 { get; set; }

    public double? Po4 { get; set; }

    public DateTime? DateChecked { get; set; }

    public virtual FishTank? FishTank { get; set; }
}
