using RentalMotorbike.BusinessObject.Entities;
using RentalMotorbike.DAOs.Implements;
using RentalMotorbike.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMotorbike.Repositories.Implements
{
    public class RentalRepository : IRentalRepository
    {
        public List<Rental> GetAllRentals() 
            => RentalDAO.Instance.GetAllRentals();
        public Rental GetRentalByID(int rentalId) 
            => RentalDAO.Instance.GetRentalByID(rentalId);
        public void AddRental(Rental rental) 
            => RentalDAO.Instance.AddRental(rental);
        public void UpdateRental(Rental rental) 
            => RentalDAO.Instance.UpdateRental(rental);
        public void DeleteRental(int rentalId) 
            => RentalDAO.Instance.DeleteRental(rentalId);
        public List<Rental> GetRentalsByUserId(int userId) 
            => RentalDAO.Instance.GetRentalsByUserId(userId);
    }
}
