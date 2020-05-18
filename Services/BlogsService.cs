using System;
using System.Collections.Generic;
using dotnet_bloggr.Models;
using dotnet_bloggr.Repositories;

namespace dotnet_bloggr.Services
{
  public class BlogsService
  {
    private readonly BlogsRepository _repo;

    public BlogsService(BlogsRepository repo)
    {
      _repo = repo;
    }
    public IEnumerable<Blog> GetAll()
    {
      return _repo.GetAll();
    }

    internal object Create(Blog newBlog)
    {
      return _repo.Create(newBlog);
    }

    internal Blog GetById(int id)
    {
      Blog foundBlog = _repo.GetById(id);
      if (foundBlog == null)
      {
        throw new Exception("Infalid id.");
      }
      return foundBlog;
    }

    internal Blog Delete(int id)
    {
      Blog foundBlog = GetById(id);
      if (_repo.Delete(id))
      {
        return foundBlog;
      }
      throw new Exception("something failed");
    }
  }
}