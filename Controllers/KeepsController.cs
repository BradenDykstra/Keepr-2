using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _ks;
    public KeepsController(KeepsService ks)
    {
      _ks = ks;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_ks.Get());
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return Unauthorized(e.Message);
      }
    }

    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> GetByUser()
    {
      return Ok(_ks.GetByUser(HttpContext.User.FindFirstValue("Id")));
    }


    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep newKeep)
    {
      try
      {
        newKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Create(newKeep));
      }
      catch (Exception e)
      {
        return Unauthorized(e.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Keep> Edit([FromBody] Keep newKeep, int id)
    {
      try
      {
        newKeep.Id = id;
        newKeep.UserId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Edit(newKeep));
      }
      catch (Exception e)
      {
        return Unauthorized(e.Message);
      }
    }

    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_ks.Delete(id, userId));
      }
      catch (Exception e)
      {
        return Unauthorized(e.Message);
      }
    }
  }
}