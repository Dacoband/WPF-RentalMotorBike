using RentalMotorbike.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMotorbike.Repositories.Interfaces
{
    public interface IMotorbikeRepository
    {
        public void AddMotorbike(Motorbike motorbike);
        public void RemoveMotorbike(int motorbikeId);
        public void UpdateMotorbike(Motorbike motorbike);
        public Motorbike GetMotorbikeById(int motorbikeId);
        public Motorbike GetMotorbikeByLicensePlate(string licensePlate);
        public List<Motorbike> GetAllMotorbikes();
        public List<Motorbike> GetMotorbikesAvailableForCustomer(int customerId);
    }
}
