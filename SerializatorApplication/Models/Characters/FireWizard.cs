namespace SerializatorApplication.Characters
{
    public class FireWizard : Mage
    {
        public ElementType ElementType { get; set; } = ElementType.Fire;

        public override List<string> stats()
        {
            return new List<string>
            {
                $"Name: {Name}",
                $"Hp: {Hp}",
                $"Dmg: {Dmg}",
                $"Intel: {Intelligence}",
                $"Dmg Type: {DamageType}",
                $"Element: {ElementType}"
            };
        }
    }
}
