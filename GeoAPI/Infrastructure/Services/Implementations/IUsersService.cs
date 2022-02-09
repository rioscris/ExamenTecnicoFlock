using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Infrastructure.Services
{
    public interface IUsersService
    {
        IList<User> GetUsers();
        User SaveUser(User user);
    }
}
