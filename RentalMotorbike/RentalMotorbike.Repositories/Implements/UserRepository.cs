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
    public class UserRepository : IUserRepository
    {
        public bool AddCustomer(User user)
            => UserDAO.Instance.AddCustomer(user);

        public User GetUserById(int userId)
            => UserDAO.Instance.GetUserById(userId);

        public User GetUserByUsername(string username)
            => UserDAO.Instance.GetUserByUsername(username);

        public User GetUserByEmail(string email)
            => UserDAO.Instance.GetUserByEmail(email);

        public User GetUserByEmailAndPassword(string email, string password)
             => UserDAO.Instance.GetUserByEmailAndPassword(email, password);

        public List<User> GetAllUsers()
           => UserDAO.Instance.GetAllUsers();

        public bool RemoveCustomer(int userId)    
            =>  UserDAO.Instance.RemoveCustomer(userId);

        public bool UpdateCustomer(User user)
            => UserDAO.Instance.UpdateCustomer(user);
        public List<User> GetCustomers()
            => UserDAO.Instance.GetAllUsers().Where(u => u.RoleId == 3).ToList();

    }
}
