using System.ComponentModel.DataAnnotations.Schema;

namespace blog_backend.Entity;

[Table("Blogs")]
public class Blog
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public bool IsFeatured { get; set; }
    
    
    public int CategoryId { get; set; }
    public Category? Category { get; set;}
}