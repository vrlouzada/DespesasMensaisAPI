using DespesasMensais.DataAccess.Repository;
using DespesasMensais.Library.Contracts.Repository;
using DespesasMensais.Library.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DespesasMensais.Testing.Repository
{
    public class AccountRepositoryTest
    {
        private IAccountRepository _accountRepository;

        public AccountRepositoryTest()
        {
            _accountRepository = new AccountRepository();
        }


        [Theory]
        [InlineData("VRLouzada", "@Abc1234")]
        public void CheckUser(string userName, string password)
        {
            var request = new AuthenticateRequest { Username = userName, Password = password };

            var response = _accountRepository.Authenticate(request);

            Assert.True(response != null);
            Assert.True(response.Name.Equals("Victor"));
            Assert.True(response.LastName.Equals("Louzada"));
            Assert.True(response.Email.Equals("vrlouzada@hotmail.com"));
        }
    }
}
