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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar chave primária e relacionamentos
            modelBuilder.Entity<Ability>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<AbilityInfo>()
                .HasKey(ai => ai.Id);

            modelBuilder.Entity<AbilityInfo>()
                .HasOne(ai => ai.Ability)
                .WithMany()
                .HasForeignKey(ai => ai.AbilityId);

            modelBuilder.Entity<GameIndices>()
                .HasKey(gi => gi.Id);

            modelBuilder.Entity<GameIndices>()
                .HasOne(gi => gi.Pokemon)
                .WithMany(p => p.GameIndices)
                .HasForeignKey(gi => gi.PokemonId);

            modelBuilder.Entity<Sprite>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Sprite>()
                .HasOne(s => s.Pokemon)
                .WithOne(p => p.Sprites)
                .HasForeignKey<Sprite>(s => s.PokemonId);

            modelBuilder.Entity<Domain.Models.Version>()
                .HasKey(v => v.Id);
        }
    }
}
