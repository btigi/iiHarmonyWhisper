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

        public void Write(AniFile aniFile, string filename)
        {
            var data = Write(aniFile);
            File.WriteAllBytes(filename, data);
        }

        public byte[] Write(AniFile aniFile)
        {
            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);

            // Ensure we have exactly 9 entries
            var entries = aniFile.Entries ?? new AniEntry[9];
            if (entries.Length != 9)
            {
                throw new ArgumentException("AniFile must have exactly 9 entries", nameof(aniFile));
            }

            for (int i = 0; i < 9; i++)
            {
                var entry = entries[i] ?? new AniEntry();
                
                bw.Write((byte)(entry.Used ? 1 : 0));
                bw.Write(entry.NumFrames);
                
                // Write Effect bytes (ensure 2 bytes)
                var effect = entry.Effect ?? new byte[2];
                if (effect.Length >= 2)
                {
                    bw.Write(effect[0]);
                    bw.Write(effect[1]);
                }
                else
                {
                    bw.Write(effect.Length > 0 ? effect[0] : (byte)0);
                    bw.Write((byte)0);
                }
                
                bw.Write(entry.OriginX);
                bw.Write(entry.OriginY);
                bw.Write(entry.Width);
                bw.Write(entry.Height);
                bw.Write(entry.EffectOriginX);
                bw.Write(entry.EffectOriginY);
                bw.Write(entry.SelectionOriginX);
                bw.Write(entry.SelectionOriginY);
                bw.Write(entry.SelectionSize);
                bw.Write(entry.EffectType);
                bw.Write(entry.EffectActivation);
            }

            return ms.ToArray();
        }
    }
}