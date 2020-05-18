using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using dotnet_bloggr.Models;

namespace dotnet_bloggr.Repositories
{
  public class BlogsRepository
  {
    private readonly IDbConnection _db;

    public BlogsRepository(IDbConnection db)
    {
      _db = db;
    }
    internal IEnumerable<Blog> GetAll()
    {
      string sql = "SELECT * FROM blogs";
      return _db.Query<Blog>(sql);
    }

    internal object Create(Blog newBlog)
    {
      string sql = @"
      INSERT INTO blogs
      (title, body, isPublished)
      VALUES
      (@Title, @Body, @IsPublished);
      SELECT LAST_INSERT_ID()";
      newBlog.Id = _db.ExecuteScalar<int>(sql, newBlog);
      return newBlog;
    }
  }
}