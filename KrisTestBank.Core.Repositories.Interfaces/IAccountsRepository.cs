using KrisTestBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Repositories.Interfaces
{
    public interface IAccountsRepository: IRepository<Account>
    {

        IEnumerable< Account> GetAccountDetailsByUserId(int uId);
       

    }
}
