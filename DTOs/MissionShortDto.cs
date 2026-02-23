namespace AcMissionsApp.DTOs
{
    public class MissionShortDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Difficulty { get; set; } = null!;
        public string? Reward { get; set; }
    }
}

