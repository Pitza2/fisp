using Microsoft.EntityFrameworkCore;
using testData.Entities;

namespace testData.database;

public class testDbContext : DbContext
{
    public testDbContext(DbContextOptions<testDbContext> options) : base(options)
    {
        
    }
    public DbSet<Student> Students { get; set; }
    public DbSet<Companie> Companii { get; set; }
}