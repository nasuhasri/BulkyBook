﻿// this will tell the EF to make the Id as a primary key and name is required in the database
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
    [Display(Name = "Display Order")]
    [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100 only!")]
    public int DisplayOrder { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now; // put default value
}
