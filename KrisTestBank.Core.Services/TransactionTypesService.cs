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
    public class TransactionTypesService: ITransactionTypesService
    {
        private readonly ITransactionTypesRepository _transactionTypesRepository;
        public TransactionTypesService(ITransactionTypesRepository transactionTypesRepository)
        {
            _transactionTypesRepository = transactionTypesRepository;
        }

        public TransactionType Create(TransactionType transactionType)
        {
            return _transactionTypesRepository.Create(transactionType);
        }

        public TransactionType Delete(TransactionType transactionType)
        {
            return _transactionTypesRepository.Delete(transactionType);
        }

        public IEnumerable<TransactionType> GetAll()
        {
            return _transactionTypesRepository.GetAll();
        }

        public TransactionType GetTransactionTypeDetailsById(int uId)
        {
            return _transactionTypesRepository.GetDetailById(uId);
        }

        public TransactionType Update(TransactionType transactionType)
        {
            return _transactionTypesRepository.Update(transactionType);
        }
    }
}
