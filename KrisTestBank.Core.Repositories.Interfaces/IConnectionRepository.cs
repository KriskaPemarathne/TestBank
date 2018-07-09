using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Repositories.Interfaces
{
    public interface IConnectionRepository
    {
        SqlConnection Connection { get; }
    }
}
