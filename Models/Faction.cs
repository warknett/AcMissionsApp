namespace AcMissionsApp.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<MissionFaction> MissionFactions { get; set; } = new List<MissionFaction>();
    }
}

