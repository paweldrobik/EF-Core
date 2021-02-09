using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCore.Data
{
    class MyDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory =
        LoggerFactory.Create(
        builder =>
        {
            builder.AddConsole();
        });
        //public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamAssignments> TeamAssignments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseLoggerFactory(MyLoggerFactory)
               .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Database;AttachDbFilename=|DataDirectory|Database.mdf;Integrated Security=True;Trusted_Connection=True;");
        }
    }
}
