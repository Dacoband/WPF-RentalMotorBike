using System;
using System.Collections.Generic;

namespace RentalMotorbike.BusinessObject.Entities;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int RoleId { get; set; }

    public virtual ICollection<Maintenance> Maintenances { get; set; } = new List<Maintenance>();

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    public virtual Role Role { get; set; } = null!;
}
