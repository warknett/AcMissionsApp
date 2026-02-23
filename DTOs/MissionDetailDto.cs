namespace AcMissionsApp.DTOs
{
    public class MissionDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Difficulty { get; set; } = null!;
        public string? Reward { get; set; }
        public List<string> Factions { get; set; } = new();
    }
}

