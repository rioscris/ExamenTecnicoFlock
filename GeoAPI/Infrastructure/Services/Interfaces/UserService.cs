using Domain;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Services.Interfaces
{
    public class UserService : IUsersService
    {
        private GeoAPIContext _context;
        public UserService(GeoAPIContext context)
        {
            _context = context;
        }
        public IList<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User SaveUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
