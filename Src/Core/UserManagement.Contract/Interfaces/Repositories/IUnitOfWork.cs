using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Contract.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitChangesAsync();
    }
}
