using DespesasMensais.Library.Contracts;
using DespesasMensais.Library.Entities;
using DespesasMensais.Library.Helpers;
using DTO = DespesasMensais.Library.DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using DespesasMensais.Library.Contracts.Repository;

namespace DespesasMensais.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }


        public DTO.UserAccount Register(DTO.UserAccount newUser) => _userRepository.Insert(newUser);

        public IEnumerable<DTO.UserAccount> GetAll() => _userRepository.GetAll();

        public DTO.UserAccount GetById(long id) => _userRepository.GetById(id);


        private string GenerateJwtToken(DTO.UserAccount user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
