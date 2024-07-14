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
        public DbSet<AnimePin> AnimePins { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenrePin> GenrePins { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReaction> CommentReactions { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Chronology> Chronologies { get; set; }
        public DbSet<ChronologyElement> ChronologyElements { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserSetting>()
                .HasOne(us => us.User)
                .WithOne(u => u.UserSettings)
                .HasForeignKey<UserSetting>(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Genre>()
                .HasMany(g => g.GenrePins)
                .WithOne(gp => gp.Genre)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<GenrePin>(x => x.HasKey(gp => new { gp.GenreId, gp.AnimeId }));
            builder.Entity<GenrePin>()
                .HasOne(g => g.Genre)
                .WithMany(a => a.GenrePins)
                .HasForeignKey(g => g.GenreId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<GenrePin>()
                .HasOne(g => g.Anime)
                .WithMany(a => a.GenrePins)
                .HasForeignKey(g => g.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Episode>()
                .HasOne(e => e.Anime)
                .WithMany(a => a.Episodes)
                .HasForeignKey(e => e.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Comment>(x => x.HasKey(gp => new { gp.AnimeId, gp.UserId }));
            builder.Entity<Comment>()
                .HasOne(c => c.Anime)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<CommentReaction>(x => x.HasKey(gp => new { gp.UserId, gp.CommentId }));
            builder.Entity<CommentReaction>()
                .HasOne(cr => cr.Comment)
                .WithMany(c => c.CommentReactions)
                .HasForeignKey(cr => cr.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<CommentReaction>()
                .HasOne(cr => cr.User)
                .WithMany(u => u.CommentReactions)
                .HasForeignKey(cr => cr.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<AnimePin>(x => x.HasKey(ap => new { ap.UserId, ap.AnimeId }));
            builder.Entity<AnimePin>()
                .HasOne(ap => ap.Anime)
                .WithMany(a => a.AnimePins)
                .HasForeignKey(ap => ap.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<AnimePin>()
                .HasOne(ap => ap.User)
                .WithMany(u => u.AnimePins)
                .HasForeignKey(ap => ap.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Notification>()
                .HasOne(n => n.Anime)
                .WithMany(a => a.Notifications)
                .HasForeignKey(n => n.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Anime>()
                .HasOne(a => a.Studio)
                .WithMany(s => s.Animes)
                .HasForeignKey(a => a.StudioId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ChronologyElement>()
                .HasOne(ce => ce.Anime)
                .WithOne(a => a.ChronologyElement)
                .HasForeignKey<ChronologyElement>(ce => ce.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<ChronologyElement>()
                .HasOne(ce => ce.Chronology)
                .WithMany(c => c.ChronologyElements)
                .HasForeignKey(ce => ce.ChronologyId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<FriendRequest>(x => x.HasKey(fr => new { fr.FirstUserId, fr.SecondUserId }));
            builder.Entity<FriendRequest>()
                .HasOne(fr => fr.FirstUser)
                .WithMany(u => u.FriendRequests)
                .HasForeignKey(fr => fr.FirstUserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<FriendRequest>()
                .HasOne(fr => fr.SecondUser)
                .WithMany(u => u.FriendRequests)
                .HasForeignKey(fr => fr.SecondUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Review>()
                .HasOne(r => r.Anime)
                .WithMany(a => a.Reviews)
                .HasForeignKey(r => r.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<EpisodePin>(x => x.HasKey(ep => new { ep.UserId, ep.AnimeId }));
            builder.Entity<EpisodePin>()
                .HasOne(ep => ep.User)
                .WithMany(u => u.EpisodePins)
                .HasForeignKey(ep => ep.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<EpisodePin>()
                .HasOne(ep => ep.Anime)
                .WithMany(a => a.EpisodePins)
                .HasForeignKey(ep => ep.AnimeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}