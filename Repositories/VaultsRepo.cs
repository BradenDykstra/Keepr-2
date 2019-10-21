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
    internal Vault GetById(int id)
    {
      string sql = "SELECT * FROM vaults WHERE id = @id";
      return _db.QueryFirstOrDefault<Vault>(sql, new { id });
    }

    public int Create(Vault newVault)
    {
      string sql = "INSERT INTO vaults (name, description, userId) VALUES (@Name, @Description, @UserId); SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newVault);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM vaults WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}