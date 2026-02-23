using AcMissionsApp.DTOs;
using AcMissionsApp.Models;
using AcMissionsApp.Repository;

namespace AcMissionsApp.Services
{
    public class FactionService
    {
        private readonly IFactionRepository _factionRepository;

        public FactionService(IFactionRepository factionRepository)
        {
            _factionRepository = factionRepository;
        }

        public async Task<List<FactionDetailDto>> GetAllAsync()
        {
            var factions = await _factionRepository.GetAllAsync();
            return factions.Select(f => new FactionDetailDto
            {
                Id = f.Id,
                Name = f.Name,
                Region = f.Region
            }).ToList();
        }

        public async Task CreateAsync(string name, string region)
        {
            var faction = new Faction
            {
                Name = name,
                Region = region
            };

            await _factionRepository.AddAsync(faction);
        }

        public async Task DeleteAsync(int id)
        {
            await _factionRepository.DeleteAsync(id);
        }
    }
}
