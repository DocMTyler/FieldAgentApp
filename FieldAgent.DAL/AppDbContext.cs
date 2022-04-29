using FieldAgent.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace FieldAgent.DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Agency> Agency { get; set; }
        public DbSet<AgencyAgent> AgencyAgent { get; set; }
        public DbSet<Agent> Agent { get; set; }
        public DbSet<Alias> Alias { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<SecurityClearance> SecurityClearance { get; set; }
        public DbSet<MissionAgent> MissionAgent { get; set; }

        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AgencyAgent>()
                .HasKey(a => new { a.AgencyID, a.AgentID });
            builder.Entity<MissionAgent>(builder =>
            {
                builder.HasKey(ma => new { ma.MissionId, ma.AgentId });
                //builder.ToTable("MissionAgent");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(SettingsManager.GetConnectionString());
            //optionsBuilder.LogTo(message => Debug.WriteLine(message), LogLevel.Information);
        }
    }
}
