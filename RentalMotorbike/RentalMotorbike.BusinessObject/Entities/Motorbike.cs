using System;
using System.Collections.Generic;

namespace RentalMotorbike.BusinessObject.Entities;

public partial class Motorbike
{
    public int MotorbikeId { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string LicensePlate { get; set; } = null!;

    public decimal RentalPricePerDay { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual MotorbikeStatus Status { get; set; } = null!;
}
