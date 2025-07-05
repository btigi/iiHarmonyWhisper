using System.Text;
using iiHarmonyWhisper.Models;

namespace iiHarmonyWhisper
{
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
                        xcrFileResult.ErrorMessage = "Invalid checksum";
                    }
                }

                xcrFileResult.Data = fileData;
                xcrFileResult.FileInfo = file;
                result.Add(xcrFileResult);
            }

            return result;
        }

        public void Write(string directoryPath, string outputPath)
        {
            var files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
            var fileList = new List<XcrFileInput>();

            foreach (var file in files)
            {
                var relativePath = Path.GetRelativePath(directoryPath, file);
                fileList.Add(XcrFileInput.FromFile(relativePath));
            }

            Write(fileList, outputPath, directoryPath);
        }

        public void Write(List<XcrFileInput> files, string outputPath, string basePath = "")
        {
            var processedFiles = new List<XcrFileInput>();

            foreach (var file in files)
            {
                var processedFile = new XcrFileInput
                {
                    Filename = file.Filename,
                    Directory = file.Directory,
                    Encrypted = file.Encrypted,
                    Checksummed = file.Checksummed
                };

                // If data is null read from file system
                if (file.Data == null)
                {
                    var fullPath = string.IsNullOrEmpty(basePath) ? Path.Combine(file.Directory, file.Filename) : Path.Combine(basePath, file.Directory, file.Filename);
                    processedFile.Data = File.ReadAllBytes(fullPath);
                }
                else
                {
                    processedFile.Data = file.Data;
                }

                processedFiles.Add(processedFile);
            }

            WriteInternal(processedFiles, outputPath);
        }

        private void WriteInternal(List<XcrFileInput> files, string outputPath)
        {
            const int maxStringLength = 255; // 256 bytes minus null terminator
            
            foreach (var file in files)
            {
                if (!string.IsNullOrEmpty(file.Filename))
                {
                    var filenameBytes = Encoding.ASCII.GetByteCount(file.Filename);
                    if (filenameBytes > maxStringLength)
                    {
                        throw new ArgumentException($"Filename '{file.Filename}' is too long ({filenameBytes} bytes). Maximum allowed is {maxStringLength} bytes.");
                    }
                }

                if (!string.IsNullOrEmpty(file.Directory))
                {
                    var directoryBytes = Encoding.ASCII.GetByteCount(file.Directory);
                    if (directoryBytes > maxStringLength)
                    {
                        throw new ArgumentException($"Directory '{file.Directory}' is too long ({directoryBytes} bytes). Maximum allowed is {maxStringLength} bytes.");
                    }
                }
            }

            using var bw = new BinaryWriter(File.Create(outputPath));

            const int headerSize = 28;
            const int fileEntrySize = 534;
            var totalFileDataSize = files.Sum(f => f.Data.Length);
            var totalSize = headerSize + (files.Count * fileEntrySize) + totalFileDataSize;

            var signatureBytes = new byte[20];
            var sigBytes = Encoding.ASCII.GetBytes(XCR_SIGNATURE);
            Array.Copy(sigBytes, signatureBytes, Math.Min(sigBytes.Length, 20));
            bw.Write(signatureBytes);
            bw.Write(files.Count);
            bw.Write(totalSize);

            var currentOffset = headerSize + (files.Count * fileEntrySize);
            var fileInfos = new List<(XcrFile fileInfo, byte[] data)>();

            foreach (var file in files)
            {
                var fileInfo = new XcrFile
                {
                    Filename = file.Filename,
                    Directory = file.Directory,
                    FileOffset = currentOffset,
                    FileLength = file.Data.Length,
                    Reserved = 0,
                    Checksum = file.Checksummed ? CalculateXorChecksum(file.Data) : 0,
                    Checksummed = (byte)(file.Checksummed ? 1 : 0),
                    Encrypted = (byte)(file.Encrypted ? 1 : 0),
                    Reserved2 = 0
                };

                fileInfos.Add((fileInfo, file.Data));
                currentOffset += file.Data.Length;
            }

            foreach (var (fileInfo, data) in fileInfos)
            {
                WriteFixedString(bw, fileInfo.Filename, 256);
                WriteFixedString(bw, fileInfo.Directory, 256);
                bw.Write(fileInfo.FileOffset);
                bw.Write(fileInfo.FileLength);
                bw.Write(fileInfo.Reserved);
                bw.Write(fileInfo.Checksum);
                bw.Write(fileInfo.Checksummed);
                bw.Write(fileInfo.Encrypted);
                bw.Write(fileInfo.Reserved2);
            }

            foreach (var (fileInfo, data) in fileInfos)
            {
                bw.Write(data);
            }
        }

        private void WriteFixedString(BinaryWriter bw, string value, int size)
        {
            var bytes = new byte[size];
            if (!string.IsNullOrEmpty(value))
            {
                var stringBytes = Encoding.ASCII.GetBytes(value);
                Array.Copy(stringBytes, bytes, Math.Min(stringBytes.Length, size - 1)); // Leave room for null terminator
            }
            bw.Write(bytes);
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