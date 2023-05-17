using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tournament_App.Models;

namespace Tournament_App.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamAnswer> TeamAnswers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TeamAnswer>().HasKey(ta => new { ta.TeamId, ta.AnswerId });
        }
    }
}