using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> GetPublic()
    {
      return _repo.Get();   
    }

    internal IEnumerable<Keep> GetByUserId(string userId)
    {
      return _repo.GetKeepsByUserId(userId);
    }
    public Keep GetById(int id)
    {
      Keep foundKeep = _repo.GetById(id);
      if (foundKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundKeep;
    }

    internal Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }


        internal Keep Edit(Keep keepToUpdate, string userId)
        {
            Keep foundKeep = GetById(keepToUpdate.Id);
            // NOTE Check if not the owner, and price is increasing
            if (foundKeep.UserId != userId && foundKeep.Keeps < keepToUpdate.Keeps)
            {
                if (_repo.IncrementKeeps(keepToUpdate))
                {
                    keepToUpdate.Keeps = foundKeep.Keeps;
                    return keepToUpdate;
                }
                throw new Exception("Could not bid on that car");
            }
            if (foundKeep.UserId == userId && _repo.Edit(keepToUpdate, userId))
            {
                return keepToUpdate;
            }
            throw new Exception("You cant edit that, it is not yo car!");
        }

    // internal Keep Edit(Keep keepToUpdate, string userId)
    // {
    //   Keep foundKeep = GetById(keepToUpdate.Id);
    //   if (foundKeep.Keeps < keepToUpdate.Keeps)
    //   {
    //     if (_repo.IncrementKeeps(keepToUpdate))
    //     {
    //     keepToUpdate.Keeps = foundKeep.Keeps + 1;
    //     return keepToUpdate;
    //     // return _repo.IncrementKeeps(keepToUpdate);  
    //     }
    //       throw new Exception(
    //         "You can't keep this.");
    //   }
    //   if (foundKeep.UserId == userId)
    //   {
    //     return keepToUpdate;
    //   }
    //   throw new Exception("You can't edit this keep.");
    //   // return _repo.IncrementKeeps(keepToUpdate);
    // }

    internal string Delete(int id, string userId)
    {
      Keep foundKeep = GetById(id);
      if (foundKeep.UserId != userId)
      {
        throw new Exception("This is not your keep!");
      }
      if (_repo.Delete(id, userId))
      {
        return "Successfully Deleted.";
      }
      throw new Exception("Something didn't work.");
    }
 }
}