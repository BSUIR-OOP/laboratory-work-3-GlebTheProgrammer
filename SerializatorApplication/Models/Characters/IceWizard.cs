namespace SerializatorApplication.Characters
{
    public class IceWizard : Mage
    {
        public ElementType ElementType { get; set; } = ElementType.Ice;

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
