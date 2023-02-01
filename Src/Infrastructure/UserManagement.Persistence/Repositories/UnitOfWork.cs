using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Interfaces.Repositories;
using UserManagement.Persistence.Contexts;

namespace UserManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserManagementDbContext _context;

        public UnitOfWork(UserManagementDbContext context)
        {
            this._context = context;
        }
        public async Task CommitChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
