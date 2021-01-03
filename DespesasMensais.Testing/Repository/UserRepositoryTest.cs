using DespesasMensais.DataAccess.Repository;
using DespesasMensais.Library.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DTO = DespesasMensais.Library.DTO;

namespace DespesasMensais.Testing.Repository
{
    public class UserRepositoryTest
    {
        private IUserRepository _userRepository;

        public UserRepositoryTest()
        {
            _userRepository = new UserRepository();
        }


        [Theory]
        [InlineData("Victor", "Louzada", "vrlouzada@hotmail.com", "VRLouzada", "@Abc1234")]
        public void Insert(string name, string lastName, string email, string userName, string password)
        {
            var user = new DTO.UserAccount
            {
                Name = name,
                LastName = lastName,
                UserName = userName,
                Email = email,
                Password = password
            };

            user = _userRepository.Insert(user);

            Assert.True(user.Id != 0);
        }

        [Theory]
        [InlineData("VRLouzada", "@Abc1234")]
        public void CheckUser(string userName, string password)
        {
            var request = new DTO.AuthenticateRequest { Username = userName, Password = password };

            var response = _userRepository.CheckUser(request);

            Assert.True(response != null);
            Assert.True(response.Name.Equals("Victor"));
            Assert.True(response.LastName.Equals("Louzada"));
            Assert.True(response.Email.Equals("vrlouzada@hotmail.com"));
        }

        [Fact]
        public void GetAll()
        {
            var response = _userRepository.GetAll();

            Assert.True(response != null);
            Assert.True(response.Count > 0);
        }

        [Theory]
        [InlineData(1L)]
        public void BetById(long userId)
        {
            var response = _userRepository.GetById(userId);

            Assert.True(response != null);
            Assert.True(response.Name.Equals("Victor"));
            Assert.True(response.LastName.Equals("Louzada"));
            Assert.True(response.Email.Equals("vrlouzada@hotmail.com"));
        }


        [Theory]
        [InlineData(1L)]
        public void Update(long userId)
        {
            var response = _userRepository.GetById(userId);

            Assert.True(response != null);
            Assert.True(response.Name.Equals("Victor"));
            Assert.True(response.LastName.Equals("Louzada"));
            Assert.True(response.Email.Equals("vrlouzada@hotmail.com"));

            response.IsActive = true;

            var isUpdated = _userRepository.Update(response);

            Assert.True(isUpdated);
        }

    }
}
