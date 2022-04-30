namespace SerializatorApplication.Characters
{
    public class Berserker : SwordMan
    {
        public Berserker(string name, uint hp, uint dmg, uint strength, uint vamp) : base(name, hp, dmg, strength)
        {
            Vampirism = vamp;
        }
        public uint Vampirism { get; set; }
    }
}
