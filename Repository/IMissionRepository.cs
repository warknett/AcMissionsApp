using AcMissionsApp.Models;

namespace AcMissionsApp.Repository
{
    public interface IMissionRepository
    {
        Task<List<Mission>> GetAllAsync();
        Task<Mission?> GetByIdAsync(int id);
        Task<List<Mission>> GetByFactionNameAsync(string factionName);
        Task AddAsync(Mission mission, List<int> factionIds);
        Task UpdateAsync(Mission mission, List<int> factionIds);
        Task DeleteAsync(int id);
    }
}

