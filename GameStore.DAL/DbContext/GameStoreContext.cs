using GameStore.DAL.Entities;
using Microsoft.EntityFrameworkCore;


namespace GameStore.DAL.DbContext
{
    public class GameStoreContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Game> Games { get; set; }

        public GameStoreContext(DbContextOptions<GameStoreContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>().Property(g => g.Name).IsRequired();
            modelBuilder.Entity<Game>().Property(g => g.Description).IsRequired();
            modelBuilder.Entity<Game>()
                        .Property(g => g.Price)
                        .HasColumnType("decimal(18,2)");
            Seed(modelBuilder);
        }
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "Crysis", Description = "FPS game from Crytek", Price = 30, IsActiveOffer = true, ImageUrl = "assets/crysis-2.jpg" },
                new Game { Id = 2, Name = "Crysis 2", Description = "FPS game from Crytek", Price = 40, IsActiveOffer = true, ImageUrl = "assets/crysis.jpg" },
                new Game { Id = 3, Name = "Red Dead Redemption 2", Description = "Developed by Rockstar", Price = 80, IsActiveOffer = false, ImageUrl = "assets/rdr2.jpg" },
                new Game { Id = 4, Name = "Warcraft 3", Description = "Developed by Blizzard", Price = 100, IsActiveOffer = true, ImageUrl = "assets/mw.jpg" },
                new Game { Id = 5, Name = "The Witcher 3", Description = "RPG game developed by CD Project Red", Price = 45, IsActiveOffer = false, ImageUrl = "assets/witcher.jpg" }
            );
        }
    }
}

