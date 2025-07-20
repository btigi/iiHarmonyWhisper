using System.Text;
using iiHarmonyWhisper.Models;
using iiHarmonyWhisper.Helpers;

namespace iiHarmonyWhisper
{
    public class ArmProcessor
    {
        public ArmFile Read(string filename)
        {
            var result = new ArmFile();

            using var br = new BinaryReader(File.OpenRead(filename));
            result.Id = br.ReadInt32();
            result.UseDefaultData = br.ReadBoolean();
            result.MovementType = br.ReadByte();

            var name = br.ReadBytes(20);
            result.ArmyName = StringHelper.TrimFromNull(Encoding.ASCII.GetString(name));

            result.SideRequirementsFlag = br.ReadInt16();
            result.SecondsToProduce = br.ReadInt16();
            result.Combat = br.ReadInt16();
            result.Speed = br.ReadInt16();
            result.Resistance = br.ReadInt16();
            result.Hits = br.ReadInt16();
            result.View = br.ReadInt16();
            result.Armor = br.ReadInt16();
            result.StrongType = br.ReadInt16();
            result.WeakType = br.ReadInt16();
            result.Unused1 = br.ReadInt16();
            result.Unused2 = br.ReadInt16();
            result.Damage = br.ReadInt16();
            result.DamageType = br.ReadInt16();
            result.DamageRange = br.ReadInt16();
            result.Width = br.ReadByte();
            result.Height = br.ReadByte();

            for (int i = 0; i < 16; i++)
            {
                result.Exclusion[i] = br.ReadInt16();
            }

            result.PsychStrength = br.ReadByte();
            result.PsychType = br.ReadByte();
            result.PsychRange = br.ReadInt16();

            result.Gold = br.ReadInt16();
            result.Metal = br.ReadInt16();
            result.Crystal = br.ReadInt16();
            result.Stone = br.ReadInt16();

            for (int i = 0; i < 4; i++)
            {
                var power = new Power();
                power.Id = br.ReadInt32();
                power.Data1 = br.ReadInt16();
                power.Data2 = br.ReadInt16();
                power.Data3 = br.ReadInt16();
                power.Data4 = br.ReadInt16();
                power.PowerUpId = br.ReadInt16();
                result.Powers[i] = power;
            }

            _ = br.ReadBytes(40); // Skip 40 bytes

            result.UnitValue = br.ReadInt16();
            result.SetUpPoints = br.ReadInt16();
            result.FidgetRate = br.ReadInt16();
            result.MoveSound = br.ReadInt16();
            result.CombatSound = br.ReadInt16();
            result.AmbientSound = br.ReadByte();

            for (int i = 0; i < 32; i++)
            {
                result.MoveAmount[i] = br.ReadByte();
            }
            result.BonesType = br.ReadInt16();
            result.DefaultAttitude = br.ReadInt16();

            for (int i = 0; i < 4; i++)
            {
                result.MoveFineTuning[i] = br.ReadInt16();
            }

            result.AttackType = br.ReadInt16();
            result.ShadowType = br.ReadInt16();
            result.Flags = br.ReadInt16();
            result.SpeechFiles = br.ReadInt16();
            result.SkinType = br.ReadInt16();
            result.DeathScream = br.ReadInt16();

            for (int i = 0; i < 8; i++)
            {
                result.CombatPoints[i] = new ArmPoint
                {
                    X = br.ReadInt16(),
                    Y = br.ReadInt16()
                };
            }

            for (int i = 0; i < 8; i++)
            {
                result.WakePoints[i] = new ArmPoint
                {
                    X = br.ReadInt16(),
                    Y = br.ReadInt16()
                };
            }

            result.Unknown1 = br.ReadByte();
            result.Unknown2 = br.ReadByte();
            result.Unknown3 = br.ReadByte();

            return result;
        }
       
        public void Write(ArmFile armFile, string filename)
        {
            var data = Write(armFile);
            File.WriteAllBytes(filename, data);
        }

        public byte[] Write(ArmFile armFile)
        {
            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);

            bw.Write(armFile.Id);
            bw.Write(armFile.UseDefaultData);
            bw.Write(armFile.MovementType);

            // Write army name as 20-byte fixed string
            WriteFixedString(bw, armFile.ArmyName, 20);

            bw.Write(armFile.SideRequirementsFlag);
            bw.Write(armFile.SecondsToProduce);
            bw.Write(armFile.Combat);
            bw.Write(armFile.Speed);
            bw.Write(armFile.Resistance);
            bw.Write(armFile.Hits);
            bw.Write(armFile.View);
            bw.Write(armFile.Armor);
            bw.Write(armFile.StrongType);
            bw.Write(armFile.WeakType);
            bw.Write(armFile.Unused1);
            bw.Write(armFile.Unused2);
            bw.Write(armFile.Damage);
            bw.Write(armFile.DamageType);
            bw.Write(armFile.DamageRange);
            bw.Write(armFile.Width);
            bw.Write(armFile.Height);

            for (int i = 0; i < 16; i++)
            {
                bw.Write(armFile.Exclusion[i]);
            }

            bw.Write(armFile.PsychStrength);
            bw.Write(armFile.PsychType);
            bw.Write(armFile.PsychRange);

            bw.Write(armFile.Gold);
            bw.Write(armFile.Metal);
            bw.Write(armFile.Crystal);
            bw.Write(armFile.Stone);

            for (int i = 0; i < 4; i++)
            {
                var power = armFile.Powers[i] ?? new Power();
                bw.Write(power.Id);
                bw.Write(power.Data1);
                bw.Write(power.Data2);
                bw.Write(power.Data3);
                bw.Write(power.Data4);
                bw.Write(power.PowerUpId);
            }

            bw.Write(new byte[40]);

            bw.Write(armFile.UnitValue);
            bw.Write(armFile.SetUpPoints);
            bw.Write(armFile.FidgetRate);
            bw.Write(armFile.MoveSound);
            bw.Write(armFile.CombatSound);
            bw.Write(armFile.AmbientSound);

            for (int i = 0; i < 32; i++)
            {
                bw.Write(armFile.MoveAmount[i]);
            }

            bw.Write(armFile.BonesType);
            bw.Write(armFile.DefaultAttitude);

            for (int i = 0; i < 4; i++)
            {
                bw.Write(armFile.MoveFineTuning[i]);
            }

            bw.Write(armFile.AttackType);
            bw.Write(armFile.ShadowType);
            bw.Write(armFile.Flags);
            bw.Write(armFile.SpeechFiles);
            bw.Write(armFile.SkinType);
            bw.Write(armFile.DeathScream);

            for (int i = 0; i < 8; i++)
            {
                var point = armFile.CombatPoints[i] ?? new ArmPoint();
                bw.Write(point.X);
                bw.Write(point.Y);
            }

            for (int i = 0; i < 8; i++)
            {
                var point = armFile.WakePoints[i] ?? new ArmPoint();
                bw.Write(point.X);
                bw.Write(point.Y);
            }

            bw.Write(armFile.Unknown1);
            bw.Write(armFile.Unknown2);
            bw.Write(armFile.Unknown3);

            return ms.ToArray();
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
    }
}