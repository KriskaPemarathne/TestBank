using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using KrisTestBank.Core.Entities;
using KrisTestBank.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KrisTestBank.Core.Controllers
{
    [Produces("application/json")]    
    [Route("api/accounts/{accountId:int}/transactions")]
    public class TransactionsController : Controller
    {
        private readonly ITransactionsService _transactionsService;
        public TransactionsController(ITransactionsService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        // GET: api/Transactions
        [HttpGet]
        public ActionResult Get()
        {
            var transactions = _transactionsService.GetAll(); ;
            return Ok(transactions);
        }

        // GET: api/Transactions/5
        [HttpGet("{id:int}", Name = "GettransactionDetailsById")]
        public ActionResult Get(int id)
        {
            var transactions = _transactionsService.GettransactionDetailsById(id);
            return Ok(transactions);
        }

        [HttpGet("{transactionId:int}/{search}", Name = "GetTrasctionForDateRange")]
        [Route("{transactionId:int}/{search}")]
        public string Get(int accountId, int transactionId, [FromQuery, Required]SearchOptions searchOptions)
        {
            return "value";
        }

        [HttpGet("{accountsId:int}", Name = "GetTrasctionForAccountNumber")]
        [Route("TransactionByAccount/{accountsId}")]
        public ActionResult GetTransactionDetailsByAccountId(int accountsId)
        {
            var transactions = _transactionsService.GetTransactionDetailsByAccountId(accountsId);
            return Ok(transactions);
        }

        [HttpPost( Name = "PostTransaction")]
        [Route("TransferTransaction")]
        public ActionResult Transfer( [FromQuery, Required]string accountName,[FromBody]Transaction transaction)
        {
            var transactions = _transactionsService.Transfer(transaction, accountName);
            return Ok(transactions);

        }



        [HttpPost]
        [Route("CreateTransaction")]
        public ActionResult Post([FromBody]Transaction transaction)
        {
            var transactions = _transactionsService.Create(transaction);
            return Ok(transactions);
        }

    }
}
