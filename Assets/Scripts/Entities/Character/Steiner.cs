using System.IO;

public class Stenier : BaseCharacter
{
    public Stenier()
    {
        Name = "Stenier";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Stenier/Stenier-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 18,
            Strength = 24,
            Magic = 12,
            Spirit = 21
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(35),
            Head = ItemManager.Armours.GetById(26),
            Body = ItemManager.Armours.GetById(72)
        };
    }
}