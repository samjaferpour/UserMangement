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
    public class RgenerateTokenService : IRgenerateTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RgenerateTokenService(IRefreshTokenRepository refreshTokenRepository, IUnitOfWork unitOfWork) 
        {
            this._refreshTokenRepository = refreshTokenRepository;
            this._unitOfWork = unitOfWork;
        }
        public async Task<TokenDto> GetRegeneratedTokenAsync(RefreshTokenDto refreshTokenDto)
        {
            var refreshToken = new RefreshToken
            {
                Token = refreshTokenDto.RefreshToken
            };
            var user = await _refreshTokenRepository.IsTokenExist(refreshToken);
            if (user != null)
            {
                var token = new TokenDto
                {
                    AccessToken = GenerateToken.GetToken(user),
                    RefreshToken = refreshTokenDto.RefreshToken,
                };
                await _refreshTokenRepository.UpdateAsync(refreshToken);
                await _unitOfWork.CommitChangesAsync();
            }
            
            return token;
        }
    }
}
