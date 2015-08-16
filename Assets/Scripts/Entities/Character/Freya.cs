using System.IO;

public class Freya : BaseCharacter
{
    public Freya()
    {
        Name = "Freya";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Freya/Freya-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 20,
            Strength = 20,
            Magic = 16,
            Spirit = 22
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(1),
            Head = ItemManager.Armours.GetById(3)
        };
    }
}