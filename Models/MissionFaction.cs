namespace AcMissionsApp.Models
{
    public class MissionFaction
    {
        public int Id { get; set; }

        public int MissionId { get; set; }
        public Mission Mission { get; set; } = null!;

        public int FactionId { get; set; }
        public Faction Faction { get; set; } = null!;
    }
}

