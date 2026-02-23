namespace AcMissionsApp.Models
{
    public class Mission
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Difficulty { get; set; } = null!;

        // AJOUT IMPORTANT
        public string Location { get; set; } = null!;

        public string? Reward { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<MissionFaction> MissionFactions { get; set; } = new List<MissionFaction>();
    }
}
