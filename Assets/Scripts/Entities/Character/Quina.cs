using System.IO;

public class Quina : BaseCharacter
{
    public Quina()
    {
        Name = "Quina";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Quina/Quina-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 14,
            Strength = 18,
            Magic = 20,
            Spirit = 11
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(1),
            Head = ItemManager.Armours.GetById(3)
        };
    }
}