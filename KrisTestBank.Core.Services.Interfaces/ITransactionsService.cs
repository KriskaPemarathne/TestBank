using KrisTestBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Services.Interfaces
{
    public interface ITransactionsService
    {
        Transaction Create(Transaction transaction);
        string Transfer(Transaction entity, string AccountName);
        Transaction Update(Transaction transaction);
        Transaction Delete(Transaction transaction);
        IEnumerable<Transaction> GetAll();
        Transaction GettransactionDetailsById(int transationId);
        IEnumerable<Transaction> GetTransactionDetailsByAccountId(int accountId);
        
    }
}
