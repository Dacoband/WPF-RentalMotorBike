using RentalMotorbike.BusinessObject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalMotorbike.Services.Interfaces
{
    public interface IUserService
    {
        public bool AddUser(User user);
        public bool RemoveUser(int userId);
        public bool UpdateUser(User user);
        public User GetUserById(int userId);
        public User GetUserByUsername(string username);
        public User GetUserByEmail(string email);
        public User GetUserByEmailAndPassword(string email, string password);
        public List<User> GetAllUsers();
    }
}
