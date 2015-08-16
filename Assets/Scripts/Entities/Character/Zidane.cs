using System.IO;

public class Zidane : BaseCharacter
{
    public Zidane()
    {
        Name = "Zidane";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Zidane/Zidane-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 23,
            Strength = 21,
            Magic = 18,
            Spirit = 23
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(1),
            Head = ItemManager.Armours.GetById(3)
        };
    }
}