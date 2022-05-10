namespace SerializatorApplication.Characters
{
    public class Mage : Human
    {
        public uint Intelligence { get; set; }
        public DamageType DamageType { get; set; } = DamageType.Magic;

        public override List<string> stats()
        {
            return new List<string>
            {
                $"Name: {Name}",
                $"Hp: {Hp}",
                $"Dmg: {Dmg}",
                $"Intel: {Intelligence}",
                $"Dmg Type: {DamageType}"
            };
        }
    }
}
