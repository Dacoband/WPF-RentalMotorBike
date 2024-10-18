using RentalMotorbike.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMotorbike.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public bool AddCustomer(User user);
        public bool RemoveCustomer(int userId);
        public bool UpdateCustomer(User user);
        public User GetUserById(int userId);
        public User GetUserByUsername(string username);
        public User GetUserByEmail(string email);
        public User GetUserByEmailAndPassword(string email, string password);
        public List<User> GetAllUsers();
        public List<User> GetCustomers();
    }
}
