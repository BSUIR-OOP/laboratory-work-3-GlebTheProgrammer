namespace SerializatorApplication.Characters
{
    public class Mage : Human
    {
        public Mage(string name, uint hp, uint dmg, uint intelligence) : base(name, hp, dmg)
        {
            Intelligence = intelligence;
        }
        public uint Intelligence { get; set; }
        public DamageType DamageType { get; set; } = DamageType.Magic;
    }
}
