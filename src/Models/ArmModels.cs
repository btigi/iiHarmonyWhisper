namespace iiHarmonyWhisper.Models
{
    public class ArmFile
    {
        public int Id { get; set; }
        public bool UseDefaultData { get; set; }
        public byte MovementType { get; set; } // land, air, sea, hover
        public string ArmyName { get; set; } = string.Empty;
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
        public Int16[] Exclusion { get; set; } = new Int16[16]; // 16 entries
        public byte PsychStrength { get; set; }
        public byte PsychType { get; set; }
        public Int16 PsychRange { get; set; }
        public Int16 Gold { get; set; }
        public Int16 Metal { get; set; }
        public Int16 Crystal { get; set; }
        public Int16 Stone { get; set; }
        public Power[] Powers { get; set; } = new Power[4]; // 4 power entries
        public Int16 UnitValue { get; set; }
        public Int16 SetUpPoints { get; set; }
        public Int16 FidgetRate { get; set; }
        public Int16 MoveSound { get; set; }
        public Int16 CombatSound { get; set; }
        public byte AmbientSound { get; set; }
        public byte[] MoveAmount { get; set; } = new byte[32]; // 32 entries
        public Int16 BonesType { get; set; }
        public Int16 DefaultAttitude { get; set; }
        public Int16[] MoveFineTuning { get; set; } = new Int16[4]; // 4 entries
        public Int16 AttackType { get; set; }
        public Int16 ShadowType { get; set; }
        public Int16 Flags { get; set; }
        public Int16 SpeechFiles { get; set; }
        public Int16 SkinType { get; set; }
        public Int16 DeathScream { get; set; }
        public ArmPoint[] CombatPoints { get; set; } = InitializePoints(); // 8 combat points with X,Y each
        public ArmPoint[] WakePoints { get; set; } = InitializePoints(); // 8 wake points with X,Y each
        public byte Unknown1 { get; set; }
        public byte Unknown2 { get; set; }
        public byte Unknown3 { get; set; }

        private static ArmPoint[] InitializePoints()
        {
            var points = new ArmPoint[8];
            for (int i = 0; i < 8; i++)
            {
                points[i] = new ArmPoint();
            }
            return points;
        }
    }

    public class Power
    {
        public int Id { get; set; }
        public Int16 Data1 { get; set; }
        public Int16 Data2 { get; set; }
        public Int16 Data3 { get; set; }
        public Int16 Data4 { get; set; }
        public Int16 PowerUpId { get; set; }
    }

    public class ArmPoint
    {
        public Int16 X { get; set; }
        public Int16 Y { get; set; }
    }
} 