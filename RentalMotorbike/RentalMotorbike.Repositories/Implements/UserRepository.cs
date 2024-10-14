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
            => UserDAO.Instance.AddUser(user);

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

        public bool RemoveUser(int userId)    
            =>  UserDAO.Instance.RemoveUser(userId);

        public bool UpdateUser(User user)
            => UserDAO.Instance.UpdateUser(user);
       
    }
}
