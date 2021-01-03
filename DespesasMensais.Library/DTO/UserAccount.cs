using System;
using System.Collections.Generic;
using System.Text;

namespace DespesasMensais.Library.DTO
{
    public class UserAccount
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
