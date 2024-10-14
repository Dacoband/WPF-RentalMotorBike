using System;
using System.Collections.Generic;

namespace RentalMotorbike.BusinessObject.Entities;

public partial class Maintenance
{
    public int MaintenanceId { get; set; }

    public int MotorbikeId { get; set; }

    public int UserId { get; set; }

    public DateTime MaintenanceDate { get; set; }

    public string? Description { get; set; }

    public decimal Cost { get; set; }

    public string Status { get; set; } = null!;

    public virtual Motorbike Motorbike { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
