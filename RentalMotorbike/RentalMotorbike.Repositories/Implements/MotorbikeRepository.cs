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
    public class MotorbikeRepository : IMotorbikeRepository
    {
        public void AddMotorbike(Motorbike motorbike) 
            => MotorbikeDAO.Instance.AddMotorbike(motorbike);
        public void RemoveMotorbike(int motorbikeId) 
            => MotorbikeDAO.Instance.RemoveMotorbike(motorbikeId);
        public void UpdateMotorbike(Motorbike motorbike) 
            => MotorbikeDAO.Instance.UpdateMotorbike(motorbike);
        public Motorbike GetMotorbikeById(int motorbikeId) 
            => MotorbikeDAO.Instance.GetMotorbikeById(motorbikeId);
        public Motorbike GetMotorbikeByLicensePlate(string licensePlate) 
            => MotorbikeDAO.Instance.GetMotorbikeByLicensePlate(licensePlate);
        public List<Motorbike> GetAllMotorbikes() 
            => MotorbikeDAO.Instance.GetAllMotorbikes();
    }
}
