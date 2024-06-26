using ENTITIES.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WorldPhone.ENTITIES.Models;

namespace WorldPhone.DAL.Context;

public class WorldPhoneDbContext : IdentityDbContext<ApplicationUser>
{
    internal object ApplicationUser;
    public WorldPhoneDbContext(DbContextOptions<WorldPhoneDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<SmartPhone> SmartPhones { get; set; }
    public DbSet<Brand> Brands { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
