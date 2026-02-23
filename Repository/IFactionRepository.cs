using AcMissionsApp.Models;

namespace AcMissionsApp.Repository
{
    public interface IFactionRepository
    {
        Task<List<Faction>> GetAllAsync();
        Task<Faction?> GetByIdAsync(int id);
        Task AddAsync(Faction faction);
        Task DeleteAsync(int id);
    }
}
