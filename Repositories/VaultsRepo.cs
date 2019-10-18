using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultsRepo
  {
    private readonly IDbConnection _db;
    public VaultsRepo(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> Get(string id)
    {
      string sql = "SELECT * FROM vaults WHERE userId = @id";
      return _db.Query<Vault>(sql, new { id });
    }

    public void Create(Vault newVault)
    {
      string sql = "INSERT INTO vaults (name, description, userId) VALUES (@Name, @Description, @UserId)";
      _db.Execute(sql, newVault);
    }

    internal Vault GetById(int id)
    {
      throw new NotImplementedException();
    }
  }
}