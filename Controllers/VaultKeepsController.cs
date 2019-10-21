using System;
using System.Collections.Generic;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;
    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpGet("{vaultId}")]
    public ActionResult<IEnumerable<VaultKeep>> Get(int vaultId)
    {
      return Ok(_vks.Get(vaultId));
    }

    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep newVK)
    {
      try
      {
        newVK.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Create(newVK));
      }
      catch (Exception e)
      {
        return Unauthorized(e.Message);
      }
    }

    [HttpPut]
    public ActionResult<string> Delete([FromBody] VaultKeep vk)
    {
      try
      {
        vk.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vks.Delete(vk));
      }
      catch (Exception e)
      {
        return Unauthorized(e.Message);
      }
    }
  }
}