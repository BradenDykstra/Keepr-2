using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepo _repo;
    public KeepsService(KeepsRepo repo)
    {
      _repo = repo;
    }
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }
    public Keep Get(int id)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Doesn't exist"); }
      return exists;
    }
    public IEnumerable<Keep> GetByUser(string id)
    {
      return _repo.GetByUser(id);
    }

    public Keep Create(Keep newKeep)
    {
      _repo.Create(newKeep);
      return newKeep;
    }

    public Keep Edit(Keep newKeep)
    {
      Keep exists = _repo.Get(newKeep.Id);
      if (exists == null) { throw new Exception("Doesn't exist"); }
      exists.Views = newKeep.Views;
      exists.Stores = newKeep.Stores;
      _repo.Edit(exists);
      return exists;
    }

    public string Delete(int id, string userId)
    {
      Keep exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Doesn't exist"); }
      if (exists.UserId != userId) { throw new Exception("That's not yours"); }
      _repo.Delete(id);
      return "Success";
    }
  }
}