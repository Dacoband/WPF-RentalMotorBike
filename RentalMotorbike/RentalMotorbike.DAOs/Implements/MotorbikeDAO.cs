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
    public class MotorbikeDAO
    {
        private RentalMotoBikeContext _context;
        private static MotorbikeDAO _instance = null;
        public MotorbikeDAO()
        {
            _context = new RentalMotoBikeContext();
        }
        public static MotorbikeDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MotorbikeDAO();
                }
                return _instance;
            }
        }
        public Motorbike GetMotorbikeById(int motorbikeId)
        {
            return _context.Motorbikes.SingleOrDefault(m => m.MotorbikeId == motorbikeId);
        }
        public Motorbike GetMotorbikeByLicensePlate(string licensePlate)
        {
            return _context.Motorbikes.SingleOrDefault(m => m.LicensePlate == licensePlate);
        }
        public List<Motorbike> GetAllMotorbikes()
        {
            return _context.Motorbikes.ToList();
        }

        public void AddMotorbike(Motorbike motorbike)
        {
                _context.Motorbikes.Add(motorbike);
                _context.SaveChanges();

        }

        public void UpdateMotorbike(Motorbike motorbike)
        {
                var motorbikeToUpdate = _context.Motorbikes.SingleOrDefault(m => m.MotorbikeId == motorbike.MotorbikeId);
                if (motorbikeToUpdate != null)
                {
                    motorbikeToUpdate.Brand = motorbike.Brand;
                    motorbikeToUpdate.Model = motorbike.Model;
                    motorbikeToUpdate.LicensePlate = motorbike.LicensePlate;
                    motorbikeToUpdate.RentalPricePerDay = motorbike.RentalPricePerDay;
                    motorbikeToUpdate.StatusId = motorbike.StatusId;
                    _context.SaveChanges();
                }
        }

        public void RemoveMotorbike(int motorbikeId)
        {
                var motorbike = _context.Motorbikes.SingleOrDefault(m => m.MotorbikeId == motorbikeId);
                if (motorbike != null)
                {
                    _context.Motorbikes.Remove(motorbike);
                    _context.SaveChanges();
                }
        }

        public List<Motorbike> GetMotorbikesByStatus(int statusId)
        {
            return _context.Motorbikes.Where(m => m.StatusId == statusId).ToList();
        }

        public List<Motorbike> GetMotorbikesByBrand(string brand)
        {
            return _context.Motorbikes.Where(m => m.Brand == brand).ToList();
        }
        public List<Motorbike> GetMotorbikesAvailableForCustomer(int userId)
        {
            // Lấy danh sách motorbike mà người dùng đã thuê
            var rentedMotorbikes = _context.Rentals
                .Where(r => r.UserId == userId)
                .Select(r => r.MotorbikeId)
                .ToList();
            // Lấy những motorbike có StatusId = 1 và không nằm trong danh sách đã thuê
            return _context.Motorbikes
                .Where(m => m.StatusId == 1 && !rentedMotorbikes.Contains(m.MotorbikeId))
                .ToList();
        }
    }
}
