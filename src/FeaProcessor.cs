using System.Text;
using iiHarmonyWhisper.Models;

namespace iiHarmonyWhisper
{
    public class FeaProcessor
    {
        public FeaFile Read(string filename)
        {
            var result = new FeaFile();

            using var br = new BinaryReader(File.OpenRead(filename));
            result.Id = br.ReadInt32();
            result.Name = TrimFromNull(Encoding.ASCII.GetString(br.ReadBytes(20)));
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

        private static string TrimFromNull(string input)
        {
            int index = input.IndexOf('\0');
            return index < 0 ? input : input.Substring(0, index);
        }
    }
}