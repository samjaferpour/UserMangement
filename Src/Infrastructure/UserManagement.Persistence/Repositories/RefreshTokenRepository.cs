using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly UserManagementDbContext _context;

        public RefreshTokenRepository(UserManagementDbContext context)
        {
            this._context = context;
        }
        public async Task CreateAsync(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> IsTokenExist(RefreshToken refreshToken)
        {
            var result = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == refreshToken.Token);
            if (result != null)
            {
                var myUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == result.UserId);
                return myUser;
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateAsync(RefreshToken refreshToken)
        {
            var currentRefreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Id == refreshToken.Id);
            if (currentRefreshToken != null)
            {
                currentRefreshToken.Token = refreshToken.Token;
                currentRefreshToken.ExpireTime = refreshToken.ExpireTime;
            }
            //var token = await _context.RefreshTokens.FirstOrDefaultAsync(r => r.Token == refreshToken.Token);
            //if (token != null)
            //{
            //    var user = await _context.Users.FirstOrDefaultAsync(Id == token.userId);
            //    var newToken = GenerateToken.GetToken(user);
            //    token.IsValid = true;
            //    token.ExpireTime = DateTime.Now.AddDays(1);
            //    token.Token = newToken.RefreshToken;                
            //}
        }
    }
}
