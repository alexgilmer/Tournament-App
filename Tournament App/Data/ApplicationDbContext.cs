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
        public virtual DbSet<Notification> Notifications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TeamAnswer>().HasKey(ta => new { ta.TeamId, ta.AnswerId });

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Team)
                .WithMany(t => t.ApplicationUsers)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Answer>()
                .HasOne(a => a.ParentAnswer)
                .WithMany(a => a.ChildAnswers)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Notification>()
                .HasIndex(n => n.Created);
        }
    }
}