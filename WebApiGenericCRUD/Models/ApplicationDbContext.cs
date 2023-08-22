using Microsoft.EntityFrameworkCore;
using WebApiGenericCRUD.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<Branch> Branch { get; set; }
    public DbSet<Department> Department { get; set; }
}