using AcMissionsApp.Data;
using AcMissionsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AcMissionsApp.Repository
{
    public class FactionRepository : IFactionRepository
    {
        private readonly AppDbContext _context;

        public FactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Faction>> GetAllAsync()
        {
            return await _context.Factions.ToListAsync();
        }

        public async Task<Faction?> GetByIdAsync(int id)
        {
            return await _context.Factions.FindAsync(id);
        }

        public async Task AddAsync(Faction faction)
        {
            _context.Factions.Add(faction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var faction = await _context.Factions.FindAsync(id);
            if (faction != null)
            {
                _context.Factions.Remove(faction);
                await _context.SaveChangesAsync();
            }
        }
    }
}

