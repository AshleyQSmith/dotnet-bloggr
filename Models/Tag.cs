namespace dotnet_bloggr.Models
{

  public class Tag
  {
    public int Id { get; set; }
    public string Title { get; set; }
  }


  // relationship model: usually search by parent which is Tag, so stored here
  // this is for the many-to-many table
  public class TagBlog
  {
    public int Id { get; set; }
    public int BlogId { get; set; }
    public int TagId { get; set; }
  }
}