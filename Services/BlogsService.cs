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
        throw new Exception("Invalid id.");
      }
      return foundBlog;
    }
    internal IEnumerable<Blog> GetBlogsByTagId(int id)
    {
      return _repo.GetBlogsByTagId(id);
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


    internal IEnumerable<Blog> GetBlogsByUserEmail(string creatorEmail)
    {
      return _repo.GetBlogsByUserEmail(creatorEmail);
    }

    internal Blog Edit(int id, Blog updatedBlog)
    {
      Blog foundBlog = GetById(id);
      // GetById is already handling our null checking for id's
      foundBlog.IsPublished = updatedBlog.IsPublished;
      foundBlog.Body = updatedBlog.Body;
      foundBlog.Title = updatedBlog.Title;
      // send on foundBlog instead of updatedBlog to limit what can be changed as well as know what key/value to edit
      return _repo.Edit(foundBlog);

    }
  }
}