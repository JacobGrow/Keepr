using Keepr.Models;

namespace keepr.Models
{
    public class DTOVaultKeep
    {
        public int Id {get; set;}
        public int VaultId {get; set;}
        public int KeepId {get; set;}
    }

    public class VaultKeep : DTOVaultKeep
    {
        public Vault Vault {get; set;}
        public Keep Keep {get; set;}
    }
}