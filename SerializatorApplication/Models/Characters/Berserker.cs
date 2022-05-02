using SerializatorApplication.Interfaces;

namespace SerializatorApplication.Characters
{
    public class Berserker : SwordMan, IHuman
    {
        public uint Vampirism { get; set; }

        public override List<string> stats()
        {
            return new List<string>
            {
                $"Name: {Name}",
                $"Hp: {Hp}",
                $"Dmg: {Dmg}",
                $"Str: {Strength}",
                $"Vamp: {Vampirism}",
                $"Dmg Type: {DamageType}"
            };
        }
    }
}
