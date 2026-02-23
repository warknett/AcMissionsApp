using AcMissionsApp.DTOs;
using AcMissionsApp.Models;
using AcMissionsApp.Repository;

namespace AcMissionsApp.Services
{
    public class MissionService
    {
        private readonly IMissionRepository _missionRepository;

        public MissionService(IMissionRepository missionRepository)
        {
            _missionRepository = missionRepository;
        }

        public async Task<List<MissionShortDto>> GetAllAsync()
        {
            var missions = await _missionRepository.GetAllAsync();
            return missions.Select(m => new MissionShortDto
            {
                Id = m.Id,
                Title = m.Title,
                Difficulty = m.Difficulty,
                Reward = m.Reward
            }).ToList();
        }

        public async Task<MissionDetailDto?> GetDetailAsync(int id)
        {
            var mission = await _missionRepository.GetByIdAsync(id);
            if (mission == null) return null;

            return new MissionDetailDto
            {
                Id = mission.Id,
                Title = mission.Title,
                Description = mission.Description,
                Difficulty = mission.Difficulty,
                Reward = mission.Reward,
                Factions = mission.MissionFactions.Select(mf => mf.Faction.Name).ToList()
            };
        }

        // 🔥 VERSION CORRIGÉE AVEC LOCATION
        public async Task CreateAsync(string title, string description, string difficulty, string? reward, string location, List<int> factionIds)
        {
            var mission = new Mission
            {
                Title = title,
                Description = description,
                Difficulty = difficulty,
                Reward = reward,
                Location = location
            };

            await _missionRepository.AddAsync(mission, factionIds);
        }

        public async Task UpdateAsync(int id, string title, string description, string difficulty, string? reward, List<int> factionIds)
        {
            var mission = await _missionRepository.GetByIdAsync(id);
            if (mission == null) return;

            mission.Title = title;
            mission.Description = description;
            mission.Difficulty = difficulty;
            mission.Reward = reward;
            mission.UpdatedAt = DateTime.Now;

            await _missionRepository.UpdateAsync(mission, factionIds);
        }

        public async Task DeleteAsync(int id)
        {
            await _missionRepository.DeleteAsync(id);
        }
    }
}


