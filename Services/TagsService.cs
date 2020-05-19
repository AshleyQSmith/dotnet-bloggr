using dotnet_bloggr.Models;
using dotnet_bloggr.Repositories;
using System.Collections.Generic;

namespace dotnet_bloggr.Services
{

  public class TagsService
  {
    private readonly TagsRepository _repo;
    public TagsService(TagsRepository repo)
    {
      _repo = repo;
    }

    internal Tag Create(Tag newTag)
    {
      return _repo.Create(newTag);
    }

    internal IEnumerable<Tag> GetAll()
    {
      return _repo.GetAll();
    }
  }
}


// creating objects to manage the relationship. different object for each one
// TagBlog
// {
//   TagId: 1,
//   BlogId: 6
// }

// TagBlog
// {
//   TagId: 2,
//   BlogId: 6
// }