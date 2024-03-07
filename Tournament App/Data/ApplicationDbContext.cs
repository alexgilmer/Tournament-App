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
        public virtual DbSet<GameData> GameData { get; set; }
        public virtual DbSet<TeamGameData> TeamGameData { get; set; }
        public virtual DbSet<FeatureControl> FeatureControls { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }

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

            builder.Entity<Team>()
                .HasIndex(t => t.ApiAlias)
                .IsUnique(true);

            builder.Entity<GameData>()
                .Property(gd => gd.Data)
                .HasColumnType("nvarchar(max)");

            builder.Entity<GameData>()
                .HasMany(gd => gd.TeamGameData)
                .WithOne(tgd => tgd.GameData)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<TeamGameData>()
                .HasKey(tgd => new { tgd.TeamId, tgd.GameDataId });

            builder.Entity<FeatureControl>()
                .HasKey(ef => ef.Name)
                .IsClustered(true);

            builder.Entity<FeatureControl>()
                .HasData(GetFeatureControls());
        }

        private static IEnumerable<FeatureControl> GetFeatureControls()
        {
            List<FeatureControl> features = new List<FeatureControl>
            {
                new FeatureControl()
                {
                    Name = Constants.FeatureFlagCapture,
                    IsEnabled = true
                },
                new FeatureControl()
                {
                    Name = Constants.FeatureRegistration,
                    IsEnabled = true
                },
                new FeatureControl()
                {
                    Name = Constants.FeaturePuzzlePages,
                    IsEnabled = true
                }
            };

            return features;
        }
    }
}