namespace SerializatorApplication.Characters
{
    public enum DamageType
    {
        Physical = 0,
        Magic = 1
    }

    public enum ElementType
    {
        Fire,
        Ice
    }

    public class Human
    {
        public Human(string name, uint hp, uint dmg)
        {
            Name = name;
            Hp = hp;
            Dmg = dmg;
        }
        public string Name { get; set; }
        public uint Hp { get; set; }
        public uint Dmg { get; set; }
    }
}
