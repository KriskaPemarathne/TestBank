using KrisTestBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Repositories.Interfaces
{
    public interface ITransactionsRepository:IRepository<Transaction>
    {
        //IEnumerable<Transaction> GetTransactionDetailsByAccountId(int accountId);
        string Transfer(Transaction entity, string AccountName);
        IEnumerable<Transaction> GetTransactionDetailsByAccountId(int accountId);
    }
}
