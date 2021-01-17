using DespesasMensais.Library.Contracts.Repository;
using DespesasMensais.Library.Contracts.Service;
using DespesasMensais.Library.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DespesasMensais.Service.Services
{
    

    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITokenService _tokenService;

        public AccountService(IAccountRepository accountRepository, ITokenService tokenService)
        {
            _accountRepository = accountRepository;
            _tokenService = tokenService;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _accountRepository.Authenticate(model);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = _tokenService.GenerateToken(user);

            return new AuthenticateResponse(user, token);
        }
    }
}
