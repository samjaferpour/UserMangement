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
    public class UserRegisterService : IUserRegisterService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRegisterService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<UserDto> Register(RegisterDto registerDto)
        {
            var response = new UserDto();
            var isUserExist = await _userRepository.IsUserExist(registerDto.Username);
            if (isUserExist)
            {
                return response;
            }
            else
            {
                var passwordsalt = PasswordManager.GetSalt(registerDto.Password);
                var passwordHash = PasswordManager.GetHash(passwordsalt);
                var user = new User
                {
                    Username = registerDto.Username,
                    PasswordSalt = passwordsalt,
                    Password = passwordHash,
                    FullName = registerDto.FullName,
                    RoleId = registerDto.RoleId,
                };
                await _userRepository.Register(user);
                await _unitOfWork.CommitChangesAsync();
                response.Id = user.Id;
                response.Username = user.Username;
                response.FullName = user.FullName;
                response.RoleId = user.RoleId;

                return response;
            }
           
        }
    }
}
