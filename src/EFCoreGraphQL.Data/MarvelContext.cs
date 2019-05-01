using EFCoreGraphQL.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGraphQL.Data
{
    public class MarvelContext : DbContext
    {
        public MarvelContext(DbContextOptions options) : base(options)
        {
            Database.SetCommandTimeout(0);
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Comic> Comic { get; set; }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Event> Event { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CharacterComic>()
                .ToTable("CharacterComics")
                .HasKey(cc => new { cc.CharacterId, cc.ComicId });
            modelBuilder.Entity<CharacterComic>()
                .HasOne(cc => cc.Character)
                .WithMany(c => c.Comics)
                .HasForeignKey(cc => cc.CharacterId);
            modelBuilder.Entity<CharacterComic>()
                .HasOne(cc => cc.Comic)
                .WithMany(c => c.Characters)
                .HasForeignKey(cc => cc.ComicId);

            modelBuilder.Entity<CharacterEvent>()
                .ToTable("CharacterEvents")
                .HasKey(cc => new { cc.CharacterId, cc.EventId });
            modelBuilder.Entity<CharacterEvent>()
                .HasOne(cc => cc.Character)
                .WithMany(c => c.Events)
                .HasForeignKey(cc => cc.CharacterId);
            modelBuilder.Entity<CharacterEvent>()
                .HasOne(cc => cc.Event)
                .WithMany(c => c.Characters)
                .HasForeignKey(cc => cc.EventId);


            modelBuilder.Entity<CharacterSerie>()
                .ToTable("CharacterSeries")
                .HasKey(cc => new { cc.CharacterId, cc.SerieId });
            modelBuilder.Entity<CharacterSerie>()
                .HasOne(cc => cc.Character)
                .WithMany(c => c.Series)
                .HasForeignKey(cc => cc.CharacterId);
            modelBuilder.Entity<CharacterSerie>()
                .HasOne(cc => cc.Serie)
                .WithMany(c => c.Characters)
                .HasForeignKey(cc => cc.SerieId);
        }
    }
}
