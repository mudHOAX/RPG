public class StatSet
{
    public StatSet()
    {
        Speed = 0;
        Strength = 0;
        Magic = 0;
        Spirit = 0;
        Attack = 0;
        Defence = 0;
        Evade = 0;
        MagicDefence = 0;
        MagicEvade = 0;
    }

    public byte Speed
    {
        get;
        set;
    }

    public byte Strength
    {
        get;
        set;
    }

    public byte Magic
    {
        get;
        set;
    }

    public byte Spirit
    {
        get;
        set;
    }

    public byte Attack
    {
        get;
        set;
    }

    public byte Defence
    {
        get;
        set;
    }

    public byte Evade
    {
        get;
        set;
    }

    public byte MagicDefence
    {
        get;
        set;
    }

    public byte MagicEvade
    {
        get;
        set;
    }

    public override bool Equals(object obj)
    {
        try
        {
            return this == (StatSet)obj;
        }
        catch
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return new { Speed, Strength, Magic, Spirit, Attack, Defence, Evade, MagicDefence, MagicEvade }.GetHashCode();
    }

    public static StatSet operator +(StatSet lhs, StatSet rhs)
    {
        return new StatSet()
        {
            Speed = lhs.Speed + rhs.Speed,
            Strength = lhs.Strength + rhs.Strength,
            Magic = lhs.Magic + rhs.Magic,
            Spirit = lhs.Spirit + rhs.Spirit,
            Attack = lhs.Attack + rhs.Attack,
            Defence = lhs.Defence + rhs.Defence,
            Evade = lhs.Evade + rhs.Evade,
            MagicDefence = lhs.MagicDefence + rhs.MagicDefence,
            MagicEvade = lhs.MagicEvade + rhs.MagicEvade
        };
    }

    public static StatSet operator -(StatSet lhs, StatSet rhs)
    {
        return new StatSet()
        {
            Speed = lhs.Speed - rhs.Speed,
            Strength = lhs.Strength - rhs.Strength,
            Magic = lhs.Magic - rhs.Magic,
            Spirit = lhs.Spirit - rhs.Spirit,
            Attack = lhs.Attack - rhs.Attack,
            Defence = lhs.Defence - rhs.Defence,
            Evade = lhs.Evade - rhs.Evade,
            MagicDefence = lhs.MagicDefence - rhs.MagicDefence,
            MagicEvade = lhs.MagicEvade - rhs.MagicEvade
        };
    }

    public static StatSet operator *(StatSet lhs, StatSet rhs)
    {
        return new StatSet()
        {
            Speed = lhs.Speed * rhs.Speed,
            Strength = lhs.Strength * rhs.Strength,
            Magic = lhs.Magic * rhs.Magic,
            Spirit = lhs.Spirit * rhs.Spirit,
            Attack = lhs.Attack * rhs.Attack,
            Defence = lhs.Defence * rhs.Defence,
            Evade = lhs.Evade * rhs.Evade,
            MagicDefence = lhs.MagicDefence * rhs.MagicDefence,
            MagicEvade = lhs.MagicEvade * rhs.MagicEvade
        };
    }

    public static StatSet operator /(StatSet lhs, StatSet rhs)
    {
        return new StatSet()
        {
            Speed = lhs.Speed / rhs.Speed,
            Strength = lhs.Strength / rhs.Strength,
            Magic = lhs.Magic / rhs.Magic,
            Spirit = lhs.Spirit / rhs.Spirit,
            Attack = lhs.Attack / rhs.Attack,
            Defence = lhs.Defence / rhs.Defence,
            Evade = lhs.Evade / rhs.Evade,
            MagicDefence = lhs.MagicDefence / rhs.MagicDefence,
            MagicEvade = lhs.MagicEvade / rhs.MagicEvade
        };
    }

    public static bool operator <(StatSet lhs, StatSet rhs)
    {
        return lhs.Speed < rhs.Speed
             && lhs.Strength < rhs.Strength
             && lhs.Magic < rhs.Magic
             && lhs.Spirit < rhs.Spirit
             && lhs.Attack < rhs.Attack
             && lhs.Defence < rhs.Defence
             && lhs.Evade < rhs.Evade
             && lhs.MagicDefence < rhs.MagicDefence
             && lhs.MagicEvade < rhs.MagicEvade;
    }

    public static bool operator >(StatSet lhs, StatSet rhs)
    {
        return lhs.Speed > rhs.Speed
             && lhs.Strength > rhs.Strength
             && lhs.Magic > rhs.Magic
             && lhs.Spirit > rhs.Spirit
             && lhs.Attack > rhs.Attack
             && lhs.Defence > rhs.Defence
             && lhs.Evade > rhs.Evade
             && lhs.MagicDefence > rhs.MagicDefence
             && lhs.MagicEvade > rhs.MagicEvade;
    }

    public static bool operator <=(StatSet lhs, StatSet rhs)
    {
        return lhs.Speed <= rhs.Speed
             && lhs.Strength <= rhs.Strength
             && lhs.Magic <= rhs.Magic
             && lhs.Spirit <= rhs.Spirit
             && lhs.Attack <= rhs.Attack
             && lhs.Defence <= rhs.Defence
             && lhs.Evade <= rhs.Evade
             && lhs.MagicDefence <= rhs.MagicDefence
             && lhs.MagicEvade <= rhs.MagicEvade;
    }

    public static bool operator >=(StatSet lhs, StatSet rhs)
    {
        return lhs.Speed >= rhs.Speed
             && lhs.Strength >= rhs.Strength
             && lhs.Magic >= rhs.Magic
             && lhs.Spirit >= rhs.Spirit
             && lhs.Attack >= rhs.Attack
             && lhs.Defence >= rhs.Defence
             && lhs.Evade >= rhs.Evade
             && lhs.MagicDefence >= rhs.MagicDefence
             && lhs.MagicEvade >= rhs.MagicEvade;
    }

    public static bool operator ==(StatSet lhs, StatSet rhs)
    {
        return lhs.Speed == rhs.Speed
            && lhs.Strength == rhs.Strength
            && lhs.Magic == rhs.Magic
            && lhs.Spirit == rhs.Spirit
            && lhs.Attack == rhs.Attack
            && lhs.Defence == rhs.Defence
            && lhs.Evade == rhs.Evade
            && lhs.MagicDefence == rhs.MagicDefence
            && lhs.MagicEvade == rhs.MagicEvade;
    }

    public static bool operator !=(StatSet lhs, StatSet rhs)
    {
        return lhs.Speed != rhs.Speed
            && lhs.Strength != rhs.Strength
            && lhs.Magic != rhs.Magic
            && lhs.Spirit != rhs.Spirit
            && lhs.Attack != rhs.Attack
            && lhs.Defence != rhs.Defence
            && lhs.Evade != rhs.Evade
            && lhs.MagicDefence != rhs.MagicDefence
            && lhs.MagicEvade != rhs.MagicEvade;
    }
}