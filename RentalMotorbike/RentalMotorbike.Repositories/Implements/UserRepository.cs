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
        public bool AddUser(User user)
        {
            return UserDAO.Instance.AddUser(user);
        }

        public User GetUserById(int userId)
        {
            return UserDAO.Instance.GetUserById(userId);
        }

        public User GetUserByUsername(string username)
        {
            return UserDAO.Instance.GetUserByUsername(username);
        }

        public User GetUserByEmail(string email)
        {
            return UserDAO.Instance.GetUserByEmail(email);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return UserDAO.Instance.GetUserByEmailAndPassword(email, password);
        }

        public List<User> GetAllUsers()
        {
            return UserDAO.Instance.GetAllUsers();
        }

        public bool RemoveUser(int userId)
        {
            return UserDAO.Instance.RemoveUser(userId);
        }

        public bool UpdateUser(User user)
        {
            return UserDAO.Instance.UpdateUser(user);
        }
    }
}
