using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTestBank.Core.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);

        T GetDetailById (int id);

        IEnumerable<T> GetAll();
    }
}
