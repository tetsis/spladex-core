using EFInfrastructure.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFInfrastructure.Contexts
{
    public class SBIDbContext : DbContext
    {
        public SBIDbContext(DbContextOptions<SBIDbContext> options) : base(options)
        {
        }

        public DbSet<ChannelDataModel> Channels { get; set; }
        public DbSet<VideoDataModel> Videos { get; set; }
        public DbSet<BattleDataModel> Battles { get; set; }
        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<EditingHistoryDataModel> EditingHistories { get; set; }
        public DbSet<BannedUserDataModel> BannedUsers { get; set; }
        public DbSet<FavoriteDataModel> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BattleDataModel>()
                .HasKey(x => new { x.VideoId, x.Index });

            modelBuilder.Entity<BattleDataModel>()
            .HasOne(p => p.Video)
            .WithMany(b => b.Battles)
            .HasForeignKey(p => p.VideoId);

            modelBuilder.Entity<FavoriteDataModel>()
                .HasKey(x => new { x.UserId, x.VideoId, x.BattleIndex });
        }
    }
}
