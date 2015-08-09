using System.Collections.Generic;

public class Weapon : Item
{
    public WeaponType Type { get; set; }

    public StatSet Stats { get; set; }

    public List<Element> ElementAttack { get; set; }

    public Dictionary<Element, ElementModifier> ElementDefence { get; set; }
}
