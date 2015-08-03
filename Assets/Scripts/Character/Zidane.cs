using UnityEngine;

public class Zidane : BaseCharacter
{
    public Zidane()
    {
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
            Head = ItemManager.Armours.GetById(14)
        };

        Debug.Log("------------------------------");
        Debug.Log("Level: " + Level);
        Debug.Log("Speed: " + Stats.Speed);
        Debug.Log("Strength: " + Stats.Strength);
        Debug.Log("Magic: " + Stats.Magic);
        Debug.Log("Spirit: " + Stats.Spirit);
        Debug.Log("Attack: " + Stats.Attack);
        Debug.Log("Defence: " + Stats.Defence);
        Debug.Log("Evade: " + Stats.Evade);
        Debug.Log("MagicDefence: " + Stats.MagicDefence);
        Debug.Log("MagicEvade: " + Stats.MagicEvade);
        Debug.Log("------------------------------");
    }
}