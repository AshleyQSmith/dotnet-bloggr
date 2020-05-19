using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using dotnet_bloggr.Models;
using dotnet_bloggr.Services;


namespace dotnet_bloggr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TagsController : ControllerBase
  {
    private readonly TagsService _ts;
    private readonly BlogsService _bs;

    public TagsController(TagsService ts, BlogsService bs)
    {
      _ts = ts;
      _bs = bs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Tag>> GetAll()
    {
      try
      {
        return Ok(_ts.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // searching by tag id
    [HttpGet("{id}/blogs")]
    public ActionResult<IEnumerable<TagBlogViewModel>> getBlogsByTagId(int id)
    {
      try
      {
        return Ok(_bs.GetBlogsByTagId(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);

      }
    }

    [HttpPost]
    public ActionResult<Tag> Create([FromBody] Tag newTag)
    {
      try
      {
        return Ok(_ts.Create(newTag));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


  }
}