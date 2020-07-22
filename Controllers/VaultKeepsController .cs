using System;
using keepr.Models;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Services
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    //Post
    [HttpPost]
    public ActionResult<DTOVaultKeep> Post([FromBody] DTOVaultKeep newDTOVaultKeep)
    {
      try
      {
        return Ok(_vks.Create(newDTOVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //DEL
    [HttpDelete("{id}")]
    public ActionResult<DTOVaultKeep> Delete(int id)
    {
     try
      {
        return Ok(_vks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}