using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_bloggr.Models;
using dotnet_bloggr.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_bloggr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BlogsController : ControllerBase
  {
    private readonly BlogsService _bs;

    public BlogsController(BlogsService bs)
    {
      _bs = bs;
    }


    [HttpGet]
    public ActionResult<IEnumerable<Blog>> GetAll()
    {
      try
      {
        return Ok(_bs.GetAll());
      }
      catch (System.Exception)
      {
        throw;
      }
    }

    [HttpGet("/user")]
    public ActionResult<IEnumerable<Blog>> GetBlogsByUserEmail()
    {
      try
      {
        string creatorEmail = "ashley@email.com";
        return Ok(_bs.GetBlogsByUserEmail(creatorEmail));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Blog> GetById(int id)
    {
      try
      {
        return Ok(_bs.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }


    [HttpPost]
    public ActionResult<Blog> Create([FromBody] Blog newBlog)
    {
      try
      {
        // hard code email for now because there is no auth0, otherwise there'd be models for user profiles
        newBlog.CreatorEmail = "ashley@email.com";
        return Ok(_bs.Create(newBlog));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<Blog> Delete(int id)
    {
      try
      {
        return Ok(_bs.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Blog> Edit(int id, [FromBody] Blog updatedBlog)
    {
      try
      {
        return Ok(_bs.Edit(id, updatedBlog));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

  }
}