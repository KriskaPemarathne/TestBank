using KrisTestBank.Core.Entities;
using KrisTestBank.Core.Repositories.Interfaces;
using KrisTestBank.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Services
{
    public class UsersService:IUsersService
    {
        private readonly IUsersRepository _userRepository;
        public UsersService(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User Create(User user)
        {
            return _userRepository.Create(user);
        }

        public User Delete(User user)
        {
            return _userRepository.Delete(user);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        public User GetUserDetailsById(int uId)
        {
            return _userRepository.GetDetailById(uId);
        }

        public User Update(User user)
        {
            return _userRepository.Update(user);
        }

       
    }
}
