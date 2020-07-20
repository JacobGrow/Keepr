using System.ComponentModel.DataAnnotations;
using Keepr.Models;

namespace keepr.Models
{
    public class Vault
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }  
    }

     public class VaultKeepViewModel : Keep
    {
        public int VaultKeepId { get; set; }
    }
}