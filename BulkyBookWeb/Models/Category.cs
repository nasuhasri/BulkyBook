namespace BulkyBookWeb.Models;

public class Category
{
    // create all properties

    public int Id { get; set; }
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now; // put default value
}
