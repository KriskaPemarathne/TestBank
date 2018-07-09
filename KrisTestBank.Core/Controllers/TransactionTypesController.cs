using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KrisTestBank.Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KrisTestBank.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/TransactionTypes")]
    public class TransactionTypesController : Controller
    {
        // GET: api/TransactionTypes
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TransactionTypes/5
        [HttpGet("{id}", Name = "GetTransactionType")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TransactionTypes
        [HttpPost]
        public void Post([FromBody]TransactionType transactionType)
        {
        }

        // PUT: api/TransactionTypes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]TransactionType transactionType)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
