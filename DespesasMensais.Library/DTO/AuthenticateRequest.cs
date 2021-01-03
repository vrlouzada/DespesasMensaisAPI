﻿using System.ComponentModel.DataAnnotations;

namespace DespesasMensais.Library.DTO
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
