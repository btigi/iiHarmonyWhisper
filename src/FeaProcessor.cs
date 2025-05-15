using System.Text;

namespace iiCommandersWarShout
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