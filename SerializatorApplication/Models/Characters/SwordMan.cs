namespace SerializatorApplication.Characters
{
    public class SwordMan : Human
    {
        public uint Strength { get; set; }
        public DamageType DamageType { get; set; } = DamageType.Physical;

        public override List<string> stats()
        {
            return new List<string>
            {
                $"Name: {Name}",
                $"Hp: {Hp}",
                $"Dmg: {Dmg}",
                $"Str: {Strength}",
                $"Dmg Type: {DamageType}"
            };
        }


    }
}
