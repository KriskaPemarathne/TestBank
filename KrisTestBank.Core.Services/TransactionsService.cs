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
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionRepository;
        public TransactionsService(ITransactionsRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public Transaction Create(Transaction transaction)
        {
            return _transactionRepository.Create(transaction);
        }

        public Transaction Delete(Transaction transaction)
        {
            return _transactionRepository.Delete(transaction);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

        
        public Transaction GettransactionDetailsById(int transactionId)
        {
            return _transactionRepository.GetDetailById(transactionId);
        }

        public string Transfer(Transaction entity, string AccountName)
        {
            return _transactionRepository.Transfer(entity, AccountName);
        }

        public Transaction Update(Transaction transaction)
        {
            return _transactionRepository.Update(transaction);
        }

        public IEnumerable<Transaction> GetTransactionDetailsByAccountId(int accountId)
        {
            return _transactionRepository.GetTransactionDetailsByAccountId(accountId);
        }
    }
}
