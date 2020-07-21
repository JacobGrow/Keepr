using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    public class VaultsController
    {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    } 

    [HttpGet("user")]
    [Authorize]
    public ActionResult<IEnumerable<Vault>> GetVaultsByUser()
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vs.GetByUserId(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      };
    }
    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      try
      {
        return Ok(_vs.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //GETKeepsByVaultID
    // [HttpGet("{vaultId}/keeps")]
    // public ActionResult<IEnumerable<VaultKeep>> GetKeepsByVaultId(int id)
    // {
    //   try
    //   {
    //     return Ok(_tis.GetIngsByTacoId(id));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }
    //POST
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault newVault)
    {
      try
      {
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //PUT
    [HttpPut("{id}")]
    public ActionResult<Vault> Edit([FromBody] Vault newVault, int id)
    {
      try
      {
        newVault.Id = id;
        return Ok(_vs.Edit(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    //DEL
    [HttpDelete("{id}")]
    public ActionResult<Vault> Delete(int id)
    {
      try
      {
        return Ok(_vs.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}