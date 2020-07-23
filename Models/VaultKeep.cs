using System.ComponentModel.DataAnnotations;
using Keepr.Models;

namespace keepr.Models
{
    public class DTOVaultKeep
    {
        public int Id {get; set;}
        [Required]
        public int VaultId {get; set;}
        [Required]
        public int KeepId {get; set;}

        public string UserId {get; set;}
    }

    public class VaultKeep : DTOVaultKeep
    {
        public Vault Vault {get; set;}
        public Keep Keep {get; set;}
    }
}