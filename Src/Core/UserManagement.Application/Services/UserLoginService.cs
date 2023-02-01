using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Dtos;
using UserManagement.Contract.Interfaces.Repositories;
using UserManagement.Contract.Interfaces.Services;
using UserManagement.Domain.Entities;
using UserManagement.Utility;

namespace UserManagement.Application.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserRepository _userRepository;

        public UserLoginService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }
        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            var user = new User
            {
                Username = loginDto.Username,
                Password= loginDto.Password,
            };
            var response = await _userRepository.Login(user);
            var token = GenerateToken.GetToken(response);
            return token;
        }
    }
}
