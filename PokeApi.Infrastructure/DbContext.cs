using Microsoft.EntityFrameworkCore;
using PokeApi.Domain.Models;

namespace PokeApi.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Master> Masters { get; set; }
        public DbSet<CapturedPokemon> CapturedPokemons { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<AbilityInfo> AbilityInfos { get; set; }
        public DbSet<GameIndices> GameIndices { get; set; }
        public DbSet<Sprite> Sprites { get; set; }
        public DbSet<Domain.Models.Version> Versions { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Ability>().HasKey(a => a.Id);
            modelBuilder.Entity<AbilityInfo>().HasKey(ai => ai.Id);
            modelBuilder.Entity<AbilityInfo>()
                .HasOne(ai => ai.Ability)
                .WithMany()
                .HasForeignKey(ai => ai.AbilityId);

            modelBuilder.Entity<GameIndices>().HasKey(gi => gi.Id);

            modelBuilder.Entity<Sprite>().HasKey(s => s.Id);

            modelBuilder.Entity<Domain.Models.Version>().HasKey(v => v.Id);

            modelBuilder.Entity<CapturedPokemon>().HasKey(cp => cp.Id);
            modelBuilder.Entity<CapturedPokemon>()
                .HasOne(cp => cp.Pokemon)
                .WithMany()
                .HasForeignKey(cp => cp.PokemonId);

            modelBuilder.Entity<CapturedPokemon>()
                .HasOne(cp => cp.Master)
                .WithMany(m => m.CapturedPokemons)
                .HasForeignKey(cp => cp.MasterId);
        }
    }
}
