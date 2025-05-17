namespace iiCommandersWarShout
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

    public class AniProcessor
    {
        public AniFile Read(string filename)
        {
            var result = new AniFile();
            result.Entries = new AniEntry[9];

            using var br = new BinaryReader(File.OpenRead(filename));
            for (int i = 0; i < 9; i++)
            {
                var entry = new AniEntry();
                entry.Used = br.ReadByte() != 0;
                entry.NumFrames = br.ReadByte();
                entry.Effect = br.ReadBytes(2);
                entry.OriginX = br.ReadInt16();
                entry.OriginY = br.ReadInt16();
                entry.Width = br.ReadInt16();
                entry.Height = br.ReadInt16();
                entry.EffectOriginX = br.ReadInt16();
                entry.EffectOriginY = br.ReadInt16();
                entry.SelectionOriginX = br.ReadInt16();
                entry.SelectionOriginY = br.ReadInt16();
                entry.SelectionSize = br.ReadInt16();
                entry.EffectType = br.ReadInt16();
                entry.EffectActivation = br.ReadInt16();
                result.Entries[i] = entry;
            }
            return result;
        }
    }
}