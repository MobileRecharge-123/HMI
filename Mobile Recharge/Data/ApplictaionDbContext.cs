using Microsoft.EntityFrameworkCore;
using MobileRechargeWebsite.Models;


public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
    public DbSet<User> users { get; set; }
    public DbSet<RechargePlan> RechargePlans { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
}
