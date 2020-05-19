using System.Data;
using dotnet_bloggr.Models;
using System;
using Dapper;
using System.Collections.Generic;

namespace dotnet_bloggr.Repositories
{
  public class TagsRepository
  {
    private readonly IDbConnection _db;
    public TagsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal TagsRepository Create(Tag newTag)
    {
      string sql = @"
      INSERT INTO tags 
      (title)
      VALUES
      (@Title);
      SELECT LAST_INSERT_ID()";
      newTag.Id = _db.ExecuteScalar<int>(sql, newTag);
      return newTag;
    }

    internal IEnumerable<Tag> GetAll()
    {
      string sql = "SELECT * FROM tags";
      return _db.Query<Tag>(sql);
    }

  }
}