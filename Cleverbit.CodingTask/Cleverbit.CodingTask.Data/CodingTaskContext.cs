using Cleverbit.CodingTask.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Cleverbit.CodingTask.Data
{
    public class CodingTaskContext : DbContext
    {
        public CodingTaskContext(DbContextOptions<CodingTaskContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<MatchDetail> MatchDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable(nameof(User));

            modelBuilder.Entity<Match>().ToTable(nameof(Match)).HasKey(m=> m.Id);

            modelBuilder.Entity<MatchDetail>().ToTable(nameof(MatchDetail)).HasKey(m => m.Id);


            modelBuilder.Entity<MatchDetail>()
                .HasOne(m => m.Match)
                .WithMany(m => m.MatchDetails)
                .HasForeignKey(m => m.MatchId);


            modelBuilder.Entity<MatchDetail>()
                .HasOne(m => m.User)
                .WithMany(m=> m.MatchDetails)
                .HasForeignKey(m => m.UserId);

        }
    }
}
