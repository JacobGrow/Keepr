using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;

namespace keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _repo;
      public VaultKeepsService(VaultKeepsRepository repo)
      {
          _repo = repo;
      }

    internal IEnumerable<VaultKeepViewModel> Get(string userId)
    {
      return _repo.GetByUser(userId);
    }
    internal DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
    {
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }
      public DTOVaultKeep Get(int Id)
      {
          DTOVaultKeep exists = _repo.GetById(Id);
          if (exists == null) { throw new Exception("Invalid VaultKeep"); }
          return exists;
      }


    internal DTOVaultKeep Delete(int id)
    {
      DTOVaultKeep exists = Get(id);
      _repo.Delete(id);
      return exists;
    }

    public IEnumerable<VaultKeep> GetKeepsByVaultId(int id)
    {
        return _repo.GetKeepsByVaultId(id);
    }
  }
}