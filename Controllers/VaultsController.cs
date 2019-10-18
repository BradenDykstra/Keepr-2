using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;
    public VaultsController(VaultsService vs)
    {
      _vs = vs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      return Ok(_vs.Get(HttpContext.User.FindFirstValue("Id")));
    }

    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault newVault)
    {
      try
      {
        newVault.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_vs.Create(newVault));
      }
      catch (Exception e)
      {
        return Unauthorized(e.Message);
      }
    }
  }
}