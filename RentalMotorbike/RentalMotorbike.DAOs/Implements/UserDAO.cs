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
    public class UserDAO 
    {
        private RentalMotoBikeContext _context;
        private static UserDAO _instance = null;
        public UserDAO()
        {
            _context = new RentalMotoBikeContext();
        }
        public static UserDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserDAO();
                }
                return _instance;
            }
        }
        public User GetUserById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.UserId == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }
        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users
                       .Include(u => u.Role)  
                       .SingleOrDefault(u => u.Email == email && u.PasswordHash == password);

        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public bool AddUser(User user)
        {
            bool isSuccess = false;
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception e)
            {
              
            }
            return isSuccess;
        }

        public bool RemoveUser(int userId)
        {
            bool isSuccess = false;
            try
            {
                User user = GetUserById(userId);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                
            }
            return isSuccess;
        }

        public bool UpdateUser(User user)
        {
            bool isSuccess = false;
            try
            {
                User existingUser = GetUserById(user.UserId);
                if (existingUser != null)
                {
                    _context.Users.Update(user);
                    _context.SaveChanges();
                    _context.Entry(user).State = EntityState.Detached;
                    isSuccess = true;
                }
            }
            catch (Exception e)
            {
                
            }
            return isSuccess;
        }
    }
}
