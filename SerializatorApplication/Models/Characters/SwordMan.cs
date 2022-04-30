namespace SerializatorApplication.Characters
{
    public class SwordMan : Human
    {
        public SwordMan(string name, uint hp, uint dmg, uint strength) : base(name, hp, dmg)
        {
            Strength = strength;
        }
        public uint Strength { get; set; }
        public DamageType DamageType { get; set; } = DamageType.Physical;
    }
}
