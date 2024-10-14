using RentalMotorbike.BusinessObject.Entities;
using RentalMotorbike.Repositories.Implements;
using RentalMotorbike.Repositories.Interfaces;
using RentalMotorbike.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMotorbike.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;

        public UserService()
        {
            _userRepo = new UserRepository();
        }

        public bool AddUser(User user)
        {
            return _userRepo.AddUser(user);
        }

        public User GetUserById(int userId)
        {
            return _userRepo.GetUserById(userId);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepo.GetUserByUsername(username);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepo.GetUserByEmail(email);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _userRepo.GetUserByEmailAndPassword(email, password);
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public bool RemoveUser(int userId)
        {
            return _userRepo.RemoveUser(userId);
        }

        public bool UpdateUser(User user)
        {
            return _userRepo.UpdateUser(user);
        }
    }
}
