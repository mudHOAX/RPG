using System.IO;

public class Vivi : BaseCharacter
{
    public Vivi()
    {
        Name = "Vivi";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Vivi/Vivi-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 16,
            Strength = 12,
            Magic = 24,
            Spirit = 19
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(50),
            Head = ItemManager.Armours.GetById(2),
            Body = ItemManager.Armours.GetById(53)
        };
    }
}