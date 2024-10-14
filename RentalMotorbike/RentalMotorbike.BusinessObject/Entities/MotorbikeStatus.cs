using System;
using System.Collections.Generic;

namespace RentalMotorbike.BusinessObject.Entities;

public partial class MotorbikeStatus
{
    public int StatusId { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Motorbike> Motorbikes { get; set; } = new List<Motorbike>();
}
