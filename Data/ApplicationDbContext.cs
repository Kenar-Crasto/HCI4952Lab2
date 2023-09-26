using CommunityApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CommunityApp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<City>? City { get; set; }
    public DbSet<Province>? Province { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<City>().Property(m => m.ProvinceCode).IsRequired();
        builder.Entity<Province>().Property(m => m.ProvinceCode).HasMaxLength(30);

        builder.Entity<City>().ToTable("City");
        builder.Entity<Province>().ToTable("Province");

        builder.Seed();
    }
}