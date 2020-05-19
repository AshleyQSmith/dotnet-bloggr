using System.ComponentModel.DataAnnotations;

namespace dotnet_bloggr.Models
{
  public class Blog
  {
    public int Id { get; set; }
    [Required]
    [MaxLength(80)]
    public string Title { get; set; }
    public string Body { get; set; }
    public bool IsPublished { get; set; }
    public string CreatorEmail { get; set; }
  }

  // use inheritance to pull properties from Blog to TagBlogViewModel
  public class TagBlogViewModel : Blog
  {
    public int TagBlogId { get; set; }

    // if you want to pull the tag
    // public string TagTitle { get; set; }
  }

}