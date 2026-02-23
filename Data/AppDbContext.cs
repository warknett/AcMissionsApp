using AcMissionsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AcMissionsApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Mission> Missions { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<MissionFaction> MissionFactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // -----------------------------
            // RELATION MANY-TO-MANY
            // -----------------------------
            modelBuilder.Entity<MissionFaction>()
                .HasOne(mf => mf.Mission)
                .WithMany(m => m.MissionFactions)
                .HasForeignKey(mf => mf.MissionId);

            modelBuilder.Entity<MissionFaction>()
                .HasOne(mf => mf.Faction)
                .WithMany(f => f.MissionFactions)
                .HasForeignKey(mf => mf.FactionId);

            // -----------------------------
            // SEED : FACTIONS
            // -----------------------------
            modelBuilder.Entity<Faction>().HasData(
                new Faction { Id = 1, Name = "Assassins", Region = "Moyen-Orient" },
                new Faction { Id = 2, Name = "Templiers", Region = "Europe" }
            );

            // -----------------------------
            // SEED : MISSIONS
            // -----------------------------
            modelBuilder.Entity<Mission>().HasData(
                new Mission
                {
                    Id = 1,
                    Title = "La Croisade du Roi Richard",
                    Description = "Altaïr doit infiltrer Acre pour éliminer Garnier de Naplouse.",
                    Difficulty = "Difficile",
                    Location = "Acre"
                },
                new Mission
                {
                    Id = 2,
                    Title = "Le Procès de Savonarole",
                    Description = "Ezio élimine les lieutenants de Savonarole à Florence.",
                    Difficulty = "Moyenne",
                    Location = "Florence"
                },
                new Mission
                {
                    Id = 3,
                    Title = "La Traque de Charles Lee",
                    Description = "Connor poursuit Charles Lee à New York.",
                    Difficulty = "Difficile",
                    Location = "New York"
                },
                new Mission
                {
                    Id = 4,
                    Title = "Le Banquet de Cléopâtre",
                    Description = "Bayek infiltre une réception pour Cléopâtre.",
                    Difficulty = "Facile",
                    Location = "Alexandrie"
                }
            );

            // -----------------------------
            // SEED : LIENS MANY-TO-MANY
            // -----------------------------
            modelBuilder.Entity<MissionFaction>().HasData(
                new MissionFaction { Id = -1, MissionId = 1, FactionId = 1 },
                new MissionFaction { Id = -2, MissionId = 2, FactionId = 1 },
                new MissionFaction { Id = -3, MissionId = 3, FactionId = 1 },
                new MissionFaction { Id = -4, MissionId = 4, FactionId = 1 }
            );
        }
    }
}




