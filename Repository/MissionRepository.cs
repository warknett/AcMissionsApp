using AcMissionsApp.Data;
using AcMissionsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AcMissionsApp.Repository
{
    public class MissionRepository : IMissionRepository
    {
        private readonly AppDbContext _context;

        public MissionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Mission>> GetAllAsync()
        {
            return await _context.Missions
                .Include(m => m.MissionFactions)
                    .ThenInclude(mf => mf.Faction)
                .ToListAsync();
        }

        public async Task<Mission?> GetByIdAsync(int id)
        {
            return await _context.Missions
                .Include(m => m.MissionFactions)
                    .ThenInclude(mf => mf.Faction)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Mission>> GetByFactionNameAsync(string factionName)
        {
            return await _context.Missions
                .Include(m => m.MissionFactions)
                    .ThenInclude(mf => mf.Faction)
                .Where(m => m.MissionFactions.Any(mf => mf.Faction.Name == factionName))
                .ToListAsync();
        }

        public async Task AddAsync(Mission mission, List<int> factionIds)
        {
            _context.Missions.Add(mission);
            await _context.SaveChangesAsync();

            foreach (var factionId in factionIds)
            {
                _context.MissionFactions.Add(new MissionFaction
                {
                    MissionId = mission.Id,
                    FactionId = factionId
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Mission mission, List<int> factionIds)
        {
            _context.Missions.Update(mission);

            var existing = _context.MissionFactions.Where(mf => mf.MissionId == mission.Id);
            _context.MissionFactions.RemoveRange(existing);

            foreach (var factionId in factionIds)
            {
                _context.MissionFactions.Add(new MissionFaction
                {
                    MissionId = mission.Id,
                    FactionId = factionId
                });
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var mission = await _context.Missions.FindAsync(id);
            if (mission != null)
            {
                _context.Missions.Remove(mission);
                await _context.SaveChangesAsync();
            }
        }
    }
}

