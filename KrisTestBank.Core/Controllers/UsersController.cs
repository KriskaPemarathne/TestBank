using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KrisTestBank.Core.Entities;
using KrisTestBank.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KrisTestBank.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _usersService.GetAll();
        }
        
        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUserById")]
        public string Get(int id)
        {
            return "value";
        }

       
    }
}
