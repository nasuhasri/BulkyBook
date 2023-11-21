using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore; // used for database, must install using nuget package

namespace BulkyBookWeb.Data;

/*
 * there are 2 models; code-first approach and db-first approach. currently, we adopt code-first approach.
 * bcs we pwriting code of the model first then create the db based on the model
 */
public class ApplicationDbContext : DbContext
{
    // receive options and pass it to the base class which is db context
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // create the category table with name as Categories and have four columns as written in category model
    public DbSet<Category> Categories { get; set; }
}
