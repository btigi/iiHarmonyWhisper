namespace iiHarmonyWhisper.Models
{
    public class FeaFile
    {
        public int Id { get; set; }
        public string Name { get; set; } // 20
        public byte Width { get; set; }
        public byte Height { get; set; }
        public Int16[] Exclusion { get; set; } // 16
        public byte Walkable { get; set; }
        public byte Flyable { get; set; }
        public byte AmbientSound { get; set; }
        public byte[] Unused { get; set; } // 4
        // 3 extra bytes?
    }
} 