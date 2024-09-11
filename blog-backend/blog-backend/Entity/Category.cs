using System.ComponentModel.DataAnnotations.Schema;

namespace blog_backend.Entity;

[Table("Categories")]
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

}