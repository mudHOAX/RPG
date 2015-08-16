using System.IO;

public class Amarant : BaseCharacter
{
    public Amarant()
    {
        Name = "Amarant";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Amarant/Amarant-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 22,
            Strength = 22,
            Magic = 13,
            Spirit = 15
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(1),
            Head = ItemManager.Armours.GetById(3)
        };
    }
}