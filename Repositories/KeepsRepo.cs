using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Keepr.Models;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Repositories
{
  public class KeepsRepo
  {
    private readonly IDbConnection _db;
    public KeepsRepo(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM keeps";
      return _db.Query<Keep>(sql);
    }

    internal Keep Get(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    public IEnumerable<Keep> GetByUser(string id)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @id";
      return _db.Query<Keep>(sql, new { id });
    }
    public void Create(Keep newKeep)
    {
      string sql = "INSERT INTO keeps (name, description, userId, img) VALUES (@Name, @Description, @UserId, @Img)";
      _db.Execute(sql, newKeep);
    }

    public void Edit(Keep newKeep)
    {
      string sql = "UPDATE keeps SET views = @Views, stores = @Stores WHERE id = @Id";
      _db.Execute(sql, newKeep);
    }

    public void Delete(int id)
    {
      string sql = "DELETE FROM keeps WHERE id = @id";
      _db.Execute(sql, new { id });
    }
  }
}