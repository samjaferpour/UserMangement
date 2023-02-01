using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Dtos;
using UserManagement.Contract.Interfaces.Services;

namespace UserManagement.Application.Services
{
    public class UserRegenerateTokenService : IUserRegenerateTokenService
    {
        public Task<TokenDto> getCurrentTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TokenDto> RegenerateToken(RefreshTokenDto refreshTokenDto)
        {
            throw new NotImplementedException();
        }
    }
}
