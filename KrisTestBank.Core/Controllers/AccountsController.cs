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
    [Route("api/accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountsService _accountsService;
        public AccountsController(IAccountsService accountsService)
        {
            _accountsService = accountsService;
        }


        // GET: api/Accounts
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Accounts/5     
        
        [HttpGet]
        [Route("AccountById/{id}")]
        public ActionResult Get(int id)
        {
            var accounts = _accountsService.GetAccountDetailsById(id);
            return Ok(accounts);
        }


        [HttpGet]
        [Route("AccountByUser/{id}")]
        public ActionResult GetAcccountsByUserId(int id)
        {
            var accounts = _accountsService.GetAccountsByUser(id);
            return Ok(accounts);
        }
        //// POST: api/Accounts
        //[HttpPost]
        //public ActionResult Post([FromBody]Account account)
        //{
        //    var accounts = _accountsService.Create(account);
        //    return Ok(accounts);
        //}

        //// PUT: api/Accounts/5
        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody]Account account)
        //{
        //    var accounts = _accountsService.Update(account);
        //    return Ok(accounts);
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    Account account = new Account();
        //    account.AccountId = id;
        //    var accounts = _accountsService.Delete(account);
        //    return Ok(accounts);
        //}
    }
}
