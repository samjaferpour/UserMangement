using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Dtos;

namespace UserManagement.Contract.Interfaces.Services
{
    public interface IUserLoginService
    {
        Task<TokenDto> Login(LoginDto loginDto);
    }
}
