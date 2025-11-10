using TeemAITalent.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TeemAITalent.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}