using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KrisTestBank.Core.Entities;

namespace KrisTestBank.Core.Services.Interfaces
{
    public interface IAccountsService
    {
        Account Create(Account account);
        Account Update(Account account);
        Account Delete(Account account);
        IEnumerable<Account> GetAll();
        IEnumerable<Account> GetAccountsByUser(int userId);
        Account GetAccountDetailsById(int acId);

       
    }
}
