using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Dtos;
using UserManagement.Domain.Entities;

namespace UserManagement.Contract.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsUserExist(string username);
        Task<Guid> Register(User user);
        Task<User> Login(User user);
        Task<TokenDto> RegenerateToken(RefreshToken refreshToken);
    }
}
