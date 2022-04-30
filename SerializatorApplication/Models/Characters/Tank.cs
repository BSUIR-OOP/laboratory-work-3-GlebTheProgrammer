namespace SerializatorApplication.Characters
{
    public class Tank : SwordMan
    {
        public Tank(string name, uint hp, uint dmg, uint strength, uint def) : base(name, hp, dmg, strength)
        {
            Defence = def;
        }
        public uint Defence { get; set; }
    }
}
