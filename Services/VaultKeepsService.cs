using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Keepr.Models;

namespace keepr.Services
{
  public class VaultKeepsService
  {
      private readonly VaultKeepsRepository _repo;
      public VaultKeepsService(VaultKeepsRepository repo)
      {
          _repo = repo;
      }

    internal IEnumerable<VaultKeepViewModel> Get()
    {
      return _repo.GetAll();
    }
    internal IEnumerable<DTOVaultKeep> GetByUser(string userId)
    {
      return _repo.GetVaultKeepsByUser(userId);
    }
    internal DTOVaultKeep GetById(int Id)
    {
       DTOVaultKeep exists = _repo.GetById(Id);
          if (exists == null) { throw new Exception("Invalid VaultKeep"); }
          return exists;
    }
    
    internal DTOVaultKeep Create(DTOVaultKeep newVaultKeep)
    {
      int id = _repo.Create(newVaultKeep);
      newVaultKeep.Id = id;
      return newVaultKeep;
    }

    //  internal VaultKeepViewModel Create(VaultKeepViewModel newVaultKeep)
    // {
    //   int id = _repo.Create(newVaultKeep);
    //   newVaultKeep.Id = id;
    //   return newVaultKeep;
    // }


    // internal DTOVaultKeep Delete(int id)
    // {
    //   DTOVaultKeep exists = (DTOVaultKeep)GetById(id);
    //   _repo.Delete(id);
    //   return exists;
    // }

    internal DTOVaultKeep Delete(int id, string userId)
    {
      DTOVaultKeep exists = GetById(id);
      _repo.Delete(id, userId);
      return exists;
    }
    public IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id, string userId)
    {
        return _repo.GetKeepsByVaultId(id, userId);
    }


  }
}