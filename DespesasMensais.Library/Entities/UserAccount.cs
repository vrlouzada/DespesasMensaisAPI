using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace DespesasMensais.Library.Entities
{
    public class UserAccount
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        public bool IsActive { get; set; }
    }
}
