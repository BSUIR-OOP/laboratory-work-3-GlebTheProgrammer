using SerializatorApplication.Interfaces;

namespace SerializatorApplication.Characters
{
    public class Tank : SwordMan
    {
        public uint Defence { get; set; }

        public override List<string> stats()
        {
            return new List<string>
            {
                $"Name: {Name}",
                $"Hp: {Hp}",
                $"Dmg: {Dmg}",
                $"Str: {Strength}",
                $"Def: {Defence}",
                $"Dmg Type: {DamageType}"
            };
        }
    }
}
