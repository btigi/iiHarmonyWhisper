namespace iiHarmonyWhisper.Models
{
    public class AniFile
    {
        public AniEntry[] Entries { get; set; } // 9 entries
    }

    public class AniEntry
    {
        public bool Used { get; set; }
        public byte NumFrames { get; set; }
        public byte[] Effect { get; set; }
        public Int16 OriginX { get; set; }
        public Int16 OriginY { get; set; }
        public Int16 Width { get; set; }
        public Int16 Height { get; set; }
        public Int16 EffectOriginX { get; set; }
        public Int16 EffectOriginY { get; set; }
        public Int16 SelectionOriginX { get; set; }
        public Int16 SelectionOriginY { get; set; }
        public Int16 SelectionSize { get; set; }
        public Int16 EffectType { get; set; }
        public Int16 EffectActivation { get; set; }
    }
} 