using System.IO;

public class Garnet : BaseCharacter
{
    public Garnet()
    {
        Name = "Garnet";
        Portrait = File.ReadAllBytes("Assets/Textures/Characters/Garnet/Garnet-Portrait.png");

        BaseStats = new StatSet
        {
            Speed = 21,
            Strength = 14,
            Magic = 23,
            Spirit = 17
        };
        
        Gear = new GearSet
        {
            Weapon = ItemManager.Weapons.GetById(16),
            Body = ItemManager.Armours.GetById(89)
        };
    }
}