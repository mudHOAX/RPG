using System.Collections.Generic;

public class Armour : Item
{
    public ArmourType Type
    {
        get;
        set;
    }

    public StatSet Stats
    {
        get;
        set;
    }

    public Element[] ElementAttack
    {
        get;
        set;
    }

    public Dictionary<Element, ElementModifier> ElementDefence
    {
        get;
        set;
    }
}
