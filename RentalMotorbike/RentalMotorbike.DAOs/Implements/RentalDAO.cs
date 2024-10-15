using Microsoft.EntityFrameworkCore;
using RentalMotorbike.BusinessObject;
using RentalMotorbike.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMotorbike.DAOs.Implements
{
    public class RentalDAO
    {
        private RentalMotoBikeContext _context;
        private static RentalDAO _instance = null;
        public RentalDAO()
        {
            _context = new RentalMotoBikeContext();
        }
        public static RentalDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RentalDAO();
                }
                return _instance;
            }
        }
        public List<Rental> GetAllRentals()
        {
            return _context.Rentals.ToList();
        }
        public Rental GetRentalByID(int rentalId) 
        {
            return _context.Rentals.SingleOrDefault(r => r.RentalId == rentalId);
        }
        public void AddRental(Rental rental)
        {
            _context.Rentals.Add(rental);
            _context.SaveChanges();
        }
        public void UpdateRental(Rental rental)
        {
            var rentalToUpdate = _context.Rentals.SingleOrDefault(r => r.RentalId == rental.RentalId);
            if (rentalToUpdate != null)
            {
                rentalToUpdate.UserId = rental.UserId;
                rentalToUpdate.MotorbikeId = rental.MotorbikeId;
                rentalToUpdate.StartDate = rental.StartDate;
                rentalToUpdate.EndDate = rental.EndDate;
                rentalToUpdate.TotalPrice = rental.TotalPrice;
                _context.SaveChanges();
            }
        }
        public void DeleteRental(int rentalId)
        {
            var rentalToDelete = _context.Rentals.SingleOrDefault(r => r.RentalId == rentalId);
            if (rentalToDelete != null)
            {
                _context.Rentals.Remove(rentalToDelete);
                _context.SaveChanges();
            }
        }
        public List<Rental> GetRentalsByUserId(int userId)
        {
            return _context.Rentals.Include(m => m.Motorbike).Where(u => u.UserId == userId).ToList();
        }
    }
}
