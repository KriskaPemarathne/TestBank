using KrisTestBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Services.Interfaces
{
    public interface IUsersService
    {
        User Create(User user);
        User Update(User user);
        User Delete(User user);
        IEnumerable<User> GetAll();
        User GetUserDetailsById(int uId);
    }
}
