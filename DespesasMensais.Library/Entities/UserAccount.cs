using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DespesasMensais.Library.Entities
{
    public class UserAccount
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
    }
}
