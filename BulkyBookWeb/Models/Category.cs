// this will tell the EF to make the Id as a primary key and name is required in the database
using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Models;

public class Category
{
    // create all properties

    // add data annotations
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now; // put default value
}
