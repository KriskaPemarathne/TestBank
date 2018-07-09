using KrisTestBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Repositories.Interfaces
{
    public interface ITransactionTypesRepository:IRepository<TransactionType>
    {
        TransactionType GetTransactionTypeById(int trTypId);
        
    }
}
