using System;
using System.Collections.Generic;

namespace CaKoi.Entities;

public partial class FishTank
{
    public int FishTankId { get; set; }

    public string? TankName { get; set; }

    public double? Volume { get; set; }

    public double? WaterFlowRate { get; set; }

    public double? PumpPower { get; set; }

    public int? OwnerId { get; set; }

    public virtual ICollection<KoiFish> KoiFishes { get; set; } = new List<KoiFish>();

    public virtual User? Owner { get; set; }

    public virtual ICollection<SaltCalculation> SaltCalculations { get; set; } = new List<SaltCalculation>();

    public virtual ICollection<WaterQuality> WaterQualities { get; set; } = new List<WaterQuality>();
}
