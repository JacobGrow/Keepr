using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using Keepr.Models;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet]
    public ActionResult<IEnumerable<VaultKeepViewModel>> Get()
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    
    [HttpGet("{id}")]
    public ActionResult<DTOVaultKeep> GetById(int id)
    {
       try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
    }

    [HttpGet("{user}")]
    [Authorize]
    public ActionResult<IEnumerable<DTOVaultKeep>> GetVaultKeepsByUser()
    {
      try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetByUser(userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
    }

    //Post
    [HttpPost]
    [Authorize]
    public ActionResult<DTOVaultKeep> Post([FromBody] DTOVaultKeep newDTOVaultKeep)
    {
      try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Create(newDTOVaultKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    //DEL
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<DTOVaultKeep> Delete(int id)
    {
     try
      {
        string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        return Ok(_vks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}