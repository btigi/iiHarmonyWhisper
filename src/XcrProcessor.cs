using System.Text;

namespace iiHarmonyWhisper
{
    public class XcrHeader
    {
        public string Signature { get; set; } // 20
        public int FileCount { get; set; }
        public int FileSize { get; set; }
    }

    public class XcrFile
    {
        public string Filename { get; set; } // 256
        public string Directory { get; set; } // 256
        public int FileOffset { get; set; }
        public int FileLength { get; set; }
        public int Reserved { get; set; }
        public int Checksum { get; set; }
        public byte Checksummed { get; set; }
        public byte Encrypted { get; set; }
        public Int16 Reserved2 { get; set; }
    }

    public class XcrFileResult
    {
        public XcrFile FileInfo { get; set; }
        public byte[] Data { get; set; }
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class XcrProcessor
    {
        const string XCR_SIGNATURE = "xcr File 1.00.\\..:&.";

        public List<XcrFileResult> Read(string filename)
        {
            var result = new List<XcrFileResult>();

            using var br = new BinaryReader(File.OpenRead(filename));
            var signature = br.ReadBytes(20);
            var fileCount = br.ReadInt32();
            var fileSize = br.ReadInt32();

            var fileInfos = new List<XcrFile>();

            for (int i = 0; i < fileCount; i++)
            {
                var xcrFile = new XcrFile
                {
                    Filename = TrimFromNull(Encoding.ASCII.GetString(br.ReadBytes(256))),
                    Directory = TrimFromNull(Encoding.ASCII.GetString(br.ReadBytes(256))),
                    FileOffset = br.ReadInt32(),
                    FileLength = br.ReadInt32(),
                    Reserved = br.ReadInt32(),
                    Checksum = br.ReadInt32(),
                    Checksummed = br.ReadByte(),
                    Encrypted = br.ReadByte(),
                    Reserved2 = br.ReadInt16(),
                };
                fileInfos.Add(xcrFile);
            }

            foreach (var file in fileInfos)
            {
                br.BaseStream.Seek(file.FileOffset, SeekOrigin.Begin);
                var fileData = br.ReadBytes(file.FileLength);

                var xcrFileResult = new XcrFileResult();
                xcrFileResult.IsValid = true;

                if (file.Checksummed > 0)
                {
                    var calculatedChecksum = CalculateXorChecksum(fileData);
                    if (calculatedChecksum != file.Checksum)
                    {
                        xcrFileResult.IsValid = false;
                        xcrFileResult.ErrorMessage = "Invalid checkum";
                    }
                }

                xcrFileResult.Data = fileData;
                xcrFileResult.FileInfo = file;
                result.Add(xcrFileResult);
            }

            return result;
        }

        private static string TrimFromNull(string input)
        {
            int index = input.IndexOf('\0');
            return index < 0 ? input : input.Substring(0, index);
        }

        private static int CalculateXorChecksum(byte[] data)
        {
            uint checksum = 0;
            for (int i = 0; i < data.Length; i += 4)
            {
                uint value = 0;
                for (int j = 0; j < 4 && i + j < data.Length; j++)
                {
                    value |= (uint)(data[i + j] << (j * 8));
                }
                checksum ^= value;
            }
            return (int)checksum;
        }
   }
}