using KrisTestBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Services.Interfaces
{
    public interface ITransactionTypesService
    {
        TransactionType Create(TransactionType transactionType);
        TransactionType Update(TransactionType transactionType);
        TransactionType Delete(TransactionType transactionType);
        IEnumerable<TransactionType> GetAll();
        TransactionType GetTransactionTypeDetailsById(int uId);
    }
}
