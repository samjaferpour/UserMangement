using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Contract.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<User> IsTokenExist(RefreshToken refreshToken);
        Task CreateAsync(RefreshToken refreshToken);
        Task UpdateAsync(RefreshToken refreshToken);
        Task DeleteAsync(Guid id);
    }
}
