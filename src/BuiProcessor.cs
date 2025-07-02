using System.Text;

namespace iiHarmonyWhisper
{
    public class BuiProcessor
    {
        public BuiFile Read(string filename)
        {
            var result = new ArmFile();

            using var br = new BinaryReader(File.OpenRead(filename));
            result.Id = br.ReadInt32();
            result.UseDefaultData = br.ReadBoolean();
            result.MovementType = br.ReadByte();

            var name = br.ReadBytes(20);
            result.ArmyName = Encoding.ASCII.GetString(name);

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

            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();
            result.Exclusion = br.ReadInt16();

            result.PsychStrength = br.ReadByte();
            result.PsychType = br.ReadByte();
            result.PsychRange = br.ReadInt16();

            result.Gold = br.ReadInt16();
            result.Metal = br.ReadInt16();
            result.Crystal = br.ReadInt16();
            result.Stone = br.ReadInt16();

            var power1 = new Power();
            power1.Id = br.ReadInt32();
            power1.Data1 = br.ReadInt16();
            power1.Data2 = br.ReadInt16();
            power1.Data3 = br.ReadInt16();
            power1.Data4 = br.ReadInt16();
            power1.PowerUpId = br.ReadInt16();

            var power2 = new Power();
            power2.Id = br.ReadInt32();
            power2.Data1 = br.ReadInt16();
            power2.Data2 = br.ReadInt16();
            power2.Data3 = br.ReadInt16();
            power2.Data4 = br.ReadInt16();
            power2.PowerUpId = br.ReadInt16();

            var power3 = new Power();
            power3.Id = br.ReadInt32();
            power3.Data1 = br.ReadInt16();
            power3.Data2 = br.ReadInt16();
            power3.Data3 = br.ReadInt16();
            power3.Data4 = br.ReadInt16();
            power3.PowerUpId = br.ReadInt16();

            var power4 = new Power();
            power4.Id = br.ReadInt32();
            power4.Data1 = br.ReadInt16();
            power4.Data2 = br.ReadInt16();
            power4.Data3 = br.ReadInt16();
            power4.Data4 = br.ReadInt16();
            power4.PowerUpId = br.ReadInt16();

            _ = br.ReadBytes(40);

            result.UnitValue = br.ReadInt16();
            result.SetUpPoints = br.ReadInt16();
            result.FidgetRate = br.ReadInt16();
            result.MoveSound = br.ReadInt16();
            result.CombatSound = br.ReadInt16();
            result.AmbientSound = br.ReadBoolean();

            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();

            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();

            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();

            result.MoveAmount = br.ReadByte();
            result.MoveAmount = br.ReadByte();

            _ = br.ReadByte();

            result.BonesType = br.ReadInt16();
            result.DefaultAttitude = br.ReadInt16();

            var moveFineTuning1 = br.ReadInt16();
            var moveFineTuning2 = br.ReadInt16();
            var moveFineTuning3 = br.ReadInt16();
            var moveFineTuning4 = br.ReadInt16();

            result.AttackType = br.ReadInt16();
            result.ShadowType = br.ReadInt16();
            result.Flags = br.ReadInt16();
            result.SpeechFiles = br.ReadInt16();
            result.SkinType = br.ReadInt16();
            result.DeathScream = br.ReadInt16();

            result.CombatPointX = br.ReadInt16(); // 8 entries
            result.CombatPointY = br.ReadInt16();
            //Wake { get; set; } // 8 entries

            return null;
        }
    }

    public class BuiFile
    {
        public int Id { get; set; }
        public bool UseDefaultData { get; set; }
        public byte MovementType { get; set; } // land, air, sea, hover
        public string ArmyName { get; set; }
        public Int16 SideRequirementsFlag { get; set; }
        public Int16 SecondsToProduce { get; set; }
        public Int16 Combat { get; set; }
        public Int16 Speed { get; set; }
        public Int16 Resistance { get; set; }
        public Int16 Hits { get; set; }
        public Int16 View { get; set; }
        public Int16 Armor { get; set; }
        public Int16 StrongType { get; set; }
        public Int16 WeakType { get; set; }
        public Int16 Unused1 { get; set; }
        public Int16 Unused2 { get; set; }
        public Int16 Damage { get; set; }
        public Int16 DamageType { get; set; }
        public Int16 DamageRange { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }
        public Int16 Exclusion { get; set; } // 16 entries
        public byte PsychStrength { get; set; }
        public byte PsychType { get; set; }
        public Int16 PsychRange { get; set; }
        public Int16 Gold { get; set; }
        public Int16 Metal { get; set; }
        public Int16 Crystal { get; set; }
        public Int16 Stone { get; set; }
        //public bool Power { get; set; }
        public Int16 UnitValue { get; set; }
        public Int16 SetUpPoints { get; set; }
        public Int16 FidgetRate { get; set; }
        public Int16 MoveSound { get; set; }
        public Int16 CombatSound { get; set; }
        public bool AmbientSound { get; set; }
        public byte MoveAmount { get; set; } // 32 entries
        public Int16 BonesType { get; set; }
        public Int16 DefaultAttitude { get; set; }
        public Int16 AttackType { get; set; }
        public Int16 ShadowType { get; set; }
        public Int16 Flags { get; set; }
        public Int16 SpeechFiles { get; set; }
        public Int16 SkinType { get; set; }
        public Int16 DeathScream { get; set; }
        public Int16 CombatPointX { get; set; }
        public Int16 CombatPointY { get; set; }
        public bool Wake { get; set; } // 8 entries
    }

    public class Power
    {
        public int Id { get; set; }
        public int Data1 { get; set; }
        public int Data2 { get; set; }
        public int Data3 { get; set; }
        public int Data4 { get; set; }
        public int PowerUpId { get; set; }
    }
}