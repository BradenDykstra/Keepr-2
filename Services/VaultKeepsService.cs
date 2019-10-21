using System;
using System.Collections.Generic;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepo _repo;
    private readonly VaultsRepo _vRepo;
    private readonly KeepsRepo _kRepo;
    public VaultKeepsService(VaultKeepsRepo repo, VaultsRepo vRepo, KeepsRepo kRepo)
    {
      _repo = repo;
      _vRepo = vRepo;
      _kRepo = kRepo;
    }

    public IEnumerable<Keep> Get(int vaultId, string userId)
    {
      return _repo.Get(vaultId, userId);
    }

    public string Create(VaultKeep newVK)
    {
      Vault vault = _vRepo.GetById(newVK.VaultId);
      Keep keep = _kRepo.Get(newVK.KeepId);
      if (vault == null || keep == null) { throw new Exception("Something doesn't exist here..."); }
      VaultKeep exists = _repo.GetByIds(newVK.VaultId, newVK.KeepId);
      if (exists != null) { throw new Exception("That keep is already in that vault"); }
      _repo.Create(newVK);
      return "Successfully created";
    }

    public string Delete(VaultKeep vk1)
    {
      VaultKeep vk = _repo.GetByIds(vk1.VaultId, vk1.KeepId);
      if (vk == null) { throw new Exception("Can't delete what doesn't exist at all"); }
      if (vk.UserId != vk1.UserId) { throw new Exception("That one ain't yours"); }
      _repo.Delete(vk.Id);
      return "Successfully deleted";
    }
  }
}