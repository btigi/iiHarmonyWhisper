using System.Text;

namespace iiCommandersWarShout
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

            var power = new Power();

            power.Id = br.ReadInt32();
            power.LevelsOfPowerUp = br.ReadInt16();

            var nameBytes = br.ReadBytes(20);
            power.Name = Encoding.ASCII.GetString(nameBytes).TrimEnd('\0');

            power.Amount1 = br.ReadInt16();
            power.Amount2 = br.ReadInt16();
            power.Amount3 = br.ReadInt16();
            power.Amount4 = br.ReadInt16();

            power.KeepRequirementLevel1 = br.ReadInt16();
            power.KeepRequirementLevel2 = br.ReadInt16();
            power.KeepRequirementLevel3 = br.ReadInt16();
            power.KeepRequirementLevel4 = br.ReadInt16();

            power.SideRequirementsFlag1 = br.ReadInt16();
            power.SideRequirementsFlag2 = br.ReadInt16();
            power.SideRequirementsFlag3 = br.ReadInt16();
            power.SideRequirementsFlag4 = br.ReadInt16();

            power.ResourceCostGold1 = br.ReadInt16();
            power.ResourceCostMetal1 = br.ReadInt16();
            power.ResourceCostCrystal1 = br.ReadInt16();
            power.ResourceCostStone1 = br.ReadInt16();

            power.ResourceCostGold2 = br.ReadInt16();
            power.ResourceCostMetal2 = br.ReadInt16();
            power.ResourceCostCrystal2 = br.ReadInt16();
            power.ResourceCostStone2 = br.ReadInt16();

            power.ResourceCostGold3 = br.ReadInt16();
            power.ResourceCostMetal3 = br.ReadInt16();
            power.ResourceCostCrystal3 = br.ReadInt16();
            power.ResourceCostStone3 = br.ReadInt16();

            power.ResourceCostGold4 = br.ReadInt16();
            power.ResourceCostMetal4 = br.ReadInt16();
            power.ResourceCostCrystal4 = br.ReadInt16();
            power.ResourceCostStone4 = br.ReadInt16();

            power.SecondsToProduce1 = br.ReadInt16();
            power.SecondsToProduce2 = br.ReadInt16();
            power.SecondsToProduce3 = br.ReadInt16();
            power.SecondsToProduce4 = br.ReadInt16();


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

            result.BonesType = br.ReadInt16();
            result.DefaultAttitude = br.ReadInt16();
            result.AttackType = br.ReadInt16();
            result.ShadowType = br.ReadInt16();
            result.Flags = br.ReadInt16();
            result.SpeechFiles = br.ReadInt16();
            result.SkinType = br.ReadInt16();
            result.DeathScream = br.ReadInt16();
            result.CombatPointX = br.ReadInt16();
            result.CombatPointY = br.ReadInt16();
            //public bool Wake { get; set; } // 8 entries

            return null;
        }
    }

    public class ArmFile
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
        public Int16 LevelsOfPowerUp { get; set; }
        public string Name { get; set; } // 20
        public Int16 Amount1 { get; set; }
        public Int16 Amount2 { get; set; }
        public Int16 Amount3 { get; set; }
        public Int16 Amount4 { get; set; }
        public Int16 KeepRequirementLevel1 { get; set; }
        public Int16 KeepRequirementLevel2 { get; set; }
        public Int16 KeepRequirementLevel3 { get; set; }
        public Int16 KeepRequirementLevel4 { get; set; }
        public Int16 SideRequirementsFlag1 { get; set; }
        public Int16 SideRequirementsFlag2 { get; set; }
        public Int16 SideRequirementsFlag3 { get; set; }
        public Int16 SideRequirementsFlag4 { get; set; }
        public Int16 ResourceCostGold1 { get; set; }
        public Int16 ResourceCostMetal1 { get; set; }
        public Int16 ResourceCostCrystal1 { get; set; }
        public Int16 ResourceCostStone1 { get; set; }
        public Int16 ResourceCostGold2 { get; set; }
        public Int16 ResourceCostMetal2 { get; set; }
        public Int16 ResourceCostCrystal2 { get; set; }
        public Int16 ResourceCostStone2 { get; set; }
        public Int16 ResourceCostGold3 { get; set; }
        public Int16 ResourceCostMetal3 { get; set; }
        public Int16 ResourceCostCrystal3 { get; set; }
        public Int16 ResourceCostStone3 { get; set; }
        public Int16 ResourceCostGold4 { get; set; }
        public Int16 ResourceCostMetal4 { get; set; }
        public Int16 ResourceCostCrystal4 { get; set; }
        public Int16 ResourceCostStone4 { get; set; }
        public Int16 SecondsToProduce1 { get; set; }
        public Int16 SecondsToProduce2 { get; set; }
        public Int16 SecondsToProduce3 { get; set; }
        public Int16 SecondsToProduce4 { get; set; }
    }
}