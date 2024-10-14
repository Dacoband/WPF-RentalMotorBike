using System;
using System.Collections.Generic;

namespace RentalMotorbike.BusinessObject.Entities;

public partial class Rental
{
    public int RentalId { get; set; }

    public int? UserId { get; set; }

    public int MotorbikeId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public decimal TotalPrice { get; set; }

    public virtual Motorbike Motorbike { get; set; } = null!;

    public virtual ICollection<RentalDetail> RentalDetails { get; set; } = new List<RentalDetail>();

    public virtual User? User { get; set; }
}
