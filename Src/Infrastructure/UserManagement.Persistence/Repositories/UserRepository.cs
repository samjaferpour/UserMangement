using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Contract.Dtos;
using UserManagement.Contract.Interfaces.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Persistence.Contexts;
using UserManagement.Utility;

namespace UserManagement.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManagementDbContext _context;

        public UserRepository(UserManagementDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> IsUserExist(string username)
        {
            var userIsExist = await _context.Users.Where(u => u.Username == username).AnyAsync();
            if (userIsExist)
            {
                return true;
            }
            return false;
        }

        public async Task<User> Login(User user)
        {
            var passwordsalt = PasswordManager.GetSalt(user.Password);
            var passwordHash = PasswordManager.GetHash(passwordsalt);
            var myUser = await _context.Users
                .Where(u => u.Username == user.Username)
                .Include(u => u.Role)
                .FirstOrDefaultAsync();
            if (myUser != null)
            {
                return myUser;
            }
            else
            {
                return null;
            }
            //if (user == null)
            //{
            //    return NotFound("User not found");
            //}
            //if (user.Password != passwordHash)
            //{
            //    return NotFound("User not found");
            //}
            //var token = GenerateToken.GetToken(user);
            //var newToken = new RefreshToken
            //{
            //    Token = token.RefreshToken,
            //    ExpireTime = DateTime.Now.AddDays(1),
            //    UserId = user.Id,
            //};
            //await _context.RefreshTokens.AddAsync(newToken);
            //await _unitOfWork.CommitChangesAsync();

            //return Ok(token);
            //return true;
        }

        public Task<TokenDto> RegenerateToken(RefreshTokenDto refreshTokenDto)
        {
            throw new NotImplementedException();
        }

        public Task<TokenDto> RegenerateToken(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> Register(User user)
        {
            //var userIsExist = await _context.Users.Where(u => u.Username == request.Username).AnyAsync();
            //if (userIsExist)
            //{
            //    return Conflict("User already exists");
            //}
            //var passwordsalt = PasswordManager.GetSalt(registerDto.Password);
            //var passwordHash = PasswordManager.GetHash(passwordsalt);
            //var user = new User
            //{
            //    Username = registerDto.Username,
            //    Password = passwordHash,
            //    FullName = registerDto.FullName,
            //    RoleId = registerDto.RoleId,
            //};
            await _context.Users.AddAsync(user);
            return user.Id;
        }
    }
}
