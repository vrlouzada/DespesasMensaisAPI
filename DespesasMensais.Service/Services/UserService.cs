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

        private List<DTO.UserAccount> _users = new List<DTO.UserAccount>
        {
            new DTO.UserAccount { Id = 1, Name = "Test", LastName = "User", UserName = "test", Password = "test", Email = "teste@teste.com" }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository userRepository)
        {
            _appSettings = appSettings.Value;
            _userRepository = userRepository;
        }

        public DTO.AuthenticateResponse Authenticate(DTO.AuthenticateRequest model)
        {
            var user = _userRepository.CheckUser(model); //_users.SingleOrDefault(x => x.UserName == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new DTO.AuthenticateResponse(user, token);
        }

        public IEnumerable<DTO.UserAccount> GetAll()
        {
            return _users;
        }

        public DTO.UserAccount GetById(long id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

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
