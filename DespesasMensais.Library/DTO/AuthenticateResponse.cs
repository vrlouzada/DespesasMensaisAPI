using DTO = DespesasMensais.Library.DTO;

namespace DespesasMensais.Library.DTO
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(DTO.UserAccount user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            Token = token;
        }
    }
}
