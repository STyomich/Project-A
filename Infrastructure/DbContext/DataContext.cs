using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.DbContext
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenrePin> GenrePins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserSetting>()
                .HasOne(us => us.User)
                .WithOne(u => u.UserSettings)
                .HasForeignKey<UserSetting>(us => us.UserId);

            builder.Entity<GenrePin>(x => x.HasKey(gp => new { gp.GenreId, gp.AnimeId }));
            builder.Entity<GenrePin>()
                .HasOne(g => g.Genre)
                .WithMany(a => a.GenrePins)
                .HasForeignKey(g => g.GenreId);
            builder.Entity<GenrePin>()
                .HasOne(g => g.Anime)
                .WithMany(a => a.GenrePins)
                .HasForeignKey(g => g.AnimeId);

        }
    }
}