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

    public Vault Create(Vault newVault)
    {
      _repo.Create(newVault);
      return newVault;
    }
  }
}