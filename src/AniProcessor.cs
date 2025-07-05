using iiHarmonyWhisper.Models;

namespace iiHarmonyWhisper
{
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