using System.Collections.Generic;
using System.Linq;

public class GearSet
{
    public Weapon Weapon { get; set; }

    public Armour Head { get; set; }

    public Armour Arm { get; set; }

    public Armour Body { get; set; }

    public Armour AddOn { get; set; }

    public StatSet Stats {
        get
        {
            StatSet stats = new StatSet();
            if (Weapon != null) stats += Weapon.Stats;
            if (Head != null) stats += Head.Stats;
            if (Arm != null) stats += Arm.Stats;
            if (Body != null) stats += Body.Stats;
            if (AddOn != null) stats += AddOn.Stats;
            return stats;
        }
    }

    public List<Element> ElementAttack
    {
        get
        {
            List<Element> elementAttack = new List<Element>();
            return elementAttack
                .Union(Weapon.ElementAttack)
                .Union(Head.ElementAttack)
                .Union(Arm.ElementAttack)
                .Union(Body.ElementAttack)
                .Union(AddOn.ElementAttack).ToList();
        }
    }

    public Dictionary<Element, ElementModifier> ElementDefence
    {
        get
        {
            Dictionary<Element, ElementModifier> elementDefence = new Dictionary<Element, ElementModifier>();
            return elementDefence
                .Union(Weapon.ElementDefence)
                .Union(Head.ElementDefence)
                .Union(Arm.ElementDefence)
                .Union(Body.ElementDefence)
                .Union(AddOn.ElementDefence).ToDictionary(i => i.Key, i => i.Value);
        }
    }
    
    public override bool Equals(object obj)
    {
        try { return this == (GearSet)obj; }
        catch { return false; }
    }

    public override int GetHashCode()
    {
        return new { Weapon, Head, Arm, Body, AddOn }.GetHashCode();
    }

    public static bool operator ==(GearSet lhs, GearSet rhs)
    {
        if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            return true;

        return lhs.Weapon == rhs.Weapon
            && lhs.Head == rhs.Head
            && lhs.Arm == rhs.Arm
            && lhs.Body == rhs.Body
            && lhs.AddOn == rhs.AddOn;
    }

    public static bool operator !=(GearSet lhs, GearSet rhs)
    {
        if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            return false;

        return lhs.Weapon != rhs.Weapon
            && lhs.Head != rhs.Head
            && lhs.Arm != rhs.Arm
            && lhs.Body != rhs.Body
            && lhs.AddOn != rhs.AddOn;
    }
}