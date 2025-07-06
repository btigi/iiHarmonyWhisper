using System.Text;
using iiHarmonyWhisper.Models;
using iiHarmonyWhisper.Helpers;

namespace iiHarmonyWhisper
{
    public class FeaProcessor
    {
        public FeaFile Read(string filename)
        {
            var result = new FeaFile();

            using var br = new BinaryReader(File.OpenRead(filename));
            result.Id = br.ReadInt32();
            result.Name = StringHelper.TrimFromNull(Encoding.ASCII.GetString(br.ReadBytes(20)));
            result.Width = br.ReadByte();
            result.Height = br.ReadByte();
            result.Exclusion = new short[16];
            for (int i = 0; i < 16; i++)
            {
                result.Exclusion[i] = br.ReadInt16();
            }
            result.Walkable = br.ReadByte();
            result.Flyable = br.ReadByte();
            result.AmbientSound = br.ReadByte();
            result.Unused = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                result.Unused[i] = br.ReadByte();
            }

            return result;
        }
    }
}