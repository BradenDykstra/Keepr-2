using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepo _repo;
    public VaultsService(VaultsRepo repo)
    {
      _repo = repo;
    }
    public IEnumerable<Vault> Get(string id)
    {
      return _repo.Get(id);
    }

    public Vault GetById(int id, string userId)
    {
      Vault exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("That don't exist, y'all"); }
      if (exists.UserId != userId) { throw new Exception("That ain't yours, y'all"); }
      return exists;
    }
    public Vault Create(Vault newVault)
    {
      int retVault = _repo.Create(newVault);
      return _repo.GetById(retVault);
    }

    public string Delete(int id, string userId)
    {
      Vault exists = _repo.GetById(id);
      if (exists == null) { throw new Exception("Can't delete what doesn't exist"); }
      if (exists.UserId != userId) { throw new Exception("Can't delete what isn't yours"); }
      _repo.Delete(id);
      return "Successfully deleted";
    }
  }
}