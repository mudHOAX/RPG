public class GearSet
{
    public Weapon Weapon
    {
        get;
        set;
    }

    public Armour Head
    {
        get;
        set;
    }

    public Armour Arm
    {
        get;
        set;
    }

    public Armour Body
    {
        get;
        set;
    }

    public Armour AddOn
    {
        get;
        set;
    }

    public override bool Equals(object obj)
    {
        try
        {
            return this == (GearSet)obj;
        }
        catch
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return new { Weapon, Head, Arm, Body, AddOn }.GetHashCode();
    }

    public static bool operator ==(GearSet lhs, GearSet rhs)
    {
        return lhs.Weapon == rhs.Weapon
            && lhs.Head == rhs.Head
            && lhs.Arm == rhs.Arm
            && lhs.Body == rhs.Body
            && lhs.AddOn == rhs.AddOn;
    }

    public static bool operator !=(GearSet lhs, GearSet rhs)
    {
        return lhs.Weapon != rhs.Weapon
            && lhs.Head != rhs.Head
            && lhs.Arm != rhs.Arm
            && lhs.Body != rhs.Body
            && lhs.AddOn != rhs.AddOn;
    }
}