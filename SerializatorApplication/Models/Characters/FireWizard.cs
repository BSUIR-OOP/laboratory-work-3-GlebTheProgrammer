namespace SerializatorApplication.Characters
{
    public class FireWizard : Mage
    {
        public FireWizard(string name, uint hp, uint dmg, uint intelligence) : base(name, hp, dmg, intelligence)
        {
        }
        public ElementType ElementType { get; set; } = ElementType.Fire;
    }
}
