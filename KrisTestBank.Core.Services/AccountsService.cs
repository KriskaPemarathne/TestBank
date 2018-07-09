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
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountRepository;
        public AccountsService(IAccountsRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account Create(Account account)
        {
            return _accountRepository.Create(account);
        }

        public Account Delete(Account account)
        {
            return _accountRepository.Delete(account);
        }

        public Account GetAccountDetailsById(int acId)
        {
            return _accountRepository.GetDetailById(acId);
        }

        public IEnumerable<Account> GetAccountsByUser(int userId)
        {
            return _accountRepository.GetAccountDetailsByUserId(userId);
        }

        public IEnumerable<Account> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public Account Update(Account account)
        {
            return _accountRepository.Update(account);
        }
    }
}
