namespace SerializatorApplication.Characters
{
    public class IceWizard : Mage
    {
        public IceWizard(string name, uint hp, uint dmg, uint intelligence) : base(name, hp, dmg, intelligence)
        {
        }

        public ElementType ElementType { get; set; } = ElementType.Ice;
    }
}
