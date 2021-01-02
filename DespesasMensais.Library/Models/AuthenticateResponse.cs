﻿using DespesasMensais.Library.Entities;

namespace DespesasMensais.Library.Models
{
    public class AuthenticateResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserAccount user, string token)
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
