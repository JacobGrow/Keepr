using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Keepr.Controllers;
using Keepr.Models;

namespace keepr.Services
{
  public class VaultsService
  {
      private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }
    internal IEnumerable<Vault> GetAll()
    {
      return _repo.GetAll();
    }
    internal IEnumerable<Vault> GetByUserId(string userId)
    {
       return _repo.GetVaultsByUserId(userId);
    }
  
  internal Vault GetById(int vaultId)
    {
      Vault foundVault = _repo.GetById(vaultId);
      if (foundVault == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVault;
    }


    internal Vault Create(Vault newVault)
    {
     return _repo.Create(newVault);
    }

      public Vault Edit(Vault editVault)
    {
      Vault original = GetById(editVault.Id);
      original.Name = editVault.Name == null ? original.Name : editVault.Name;
      original.Description = editVault.Description == null ? original.Description : editVault.Description;
      return _repo.Edit(original);
    }
   public string Delete(int id, string userId)
    {
     Vault foundVault = GetById(id);
            if (foundVault.UserId != userId)
            {
                throw new Exception("This is not your vault!");
            }
            if (_repo.Delete(id, userId))
            {
                return "Sucessfully delorted.";
            }
            throw new Exception("Somethin bad happened");
    }

  }
}