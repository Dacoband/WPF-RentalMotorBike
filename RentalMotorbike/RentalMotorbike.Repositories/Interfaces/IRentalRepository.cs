using RentalMotorbike.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMotorbike.Repositories.Interfaces
{
    public interface IRentalRepository
    {
        public List<Rental> GetAllRentals();
        public Rental GetRentalByID(int rentalId);
        public void AddRental(Rental rental);
        public void UpdateRental(Rental rental);
        public void DeleteRental(int rentalId);
        public List<Rental> GetRentalsByUserId(int userId);
    }
}
