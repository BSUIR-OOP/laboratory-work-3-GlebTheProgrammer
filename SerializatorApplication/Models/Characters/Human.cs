using SerializatorApplication.Interfaces;

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

    public class Human : IHuman
    {
        public string Name { get; set; }
        public uint Hp { get; set; }
        public uint Dmg { get; set; }

        public virtual List<string> stats()
        {
            return new List<string>
            {
                $"Name: {Name}",
                $"Hp: {Hp}",
                $"Dmg: {Dmg}",
                $"Dmg Type: None"
            };
        }
    }
}
