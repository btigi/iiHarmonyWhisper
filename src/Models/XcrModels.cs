namespace iiHarmonyWhisper.Models
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

    public class XcrFileInput
    {
        public string Filename { get; set; }
        public string Directory { get; set; }
        public byte[] Data { get; set; }  // null = read from file system
        public bool Encrypted { get; set; }
        public bool Checksummed { get; set; }

        public static XcrFileInput FromFile(string filename, bool encrypted = false, bool checksummed = false)
        {
            return new XcrFileInput
            {
                Filename = Path.GetFileName(filename),
                Directory = Path.GetDirectoryName(filename) ?? string.Empty,
                Data = null!,
                Encrypted = encrypted,
                Checksummed = checksummed
            };
        }

        public static XcrFileInput FromData(byte[] data, string filename, string directory = "", bool encrypted = false, bool checksummed = false)
        {
            return new XcrFileInput
            {
                Filename = filename,
                Directory = directory,
                Data = data,
                Encrypted = encrypted,
                Checksummed = checksummed
            };
        }
    }
} 