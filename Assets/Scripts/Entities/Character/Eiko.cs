using System.IO;

public class Eiko : BaseCharacter
{
    public Eiko()
    {
        Name = "Eiko";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Eiko/Eiko-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 19,
            Strength = 13,
            Magic = 21,
            Spirit = 18
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(1),
            Head = ItemManager.Armours.GetById(3)
        };
    }
}