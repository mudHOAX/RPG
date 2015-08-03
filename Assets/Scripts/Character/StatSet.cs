public class StatSet
{
    const byte MAX_SPEED = 50;
    const byte MAX_STRENGTH = 99;
    const byte MAX_MAGIC = 99;
    const byte MAX_SPIRIT = 50;

    private byte speed = 0;
    private byte strength = 0;
    private byte magic = 0;
    private byte spirit = 0;

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
        get { return speed; }
        set
        {
            if (value > MAX_SPEED)
                speed = MAX_SPEED;
            else
                speed = value;
        }
    }

    public byte Strength
    {
        get { return strength; }
        set
        {
            if (value > MAX_STRENGTH)
                strength = MAX_STRENGTH;
            else
                strength = value;
        }
    }

    public byte Magic
    {
        get { return magic; }
        set
        {
            if (value > MAX_MAGIC)
                magic = MAX_MAGIC;
            else
                magic = value;
        }
    }

    public byte Spirit
    {
        get { return spirit; }
        set
        {
            if (value > MAX_SPIRIT)
                spirit = MAX_SPIRIT;
            else
                spirit = value;
        }
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
            Speed = (byte)(lhs.Speed + rhs.Speed),
            Strength = (byte)(lhs.Strength + rhs.Strength),
            Magic = (byte)(lhs.Magic + rhs.Magic),
            Spirit = (byte)(lhs.Spirit + rhs.Spirit),
            Attack = (byte)(lhs.Attack + rhs.Attack),
            Defence = (byte)(lhs.Defence + rhs.Defence),
            Evade = (byte)(lhs.Evade + rhs.Evade),
            MagicDefence = (byte)(lhs.MagicDefence + rhs.MagicDefence),
            MagicEvade = (byte)(lhs.MagicEvade + rhs.MagicEvade)
        };
    }

    public static StatSet operator -(StatSet lhs, StatSet rhs)
    {
        return new StatSet()
        {
            Speed = (byte)(lhs.Speed - rhs.Speed),
            Strength = (byte)(lhs.Strength - rhs.Strength),
            Magic = (byte)(lhs.Magic - rhs.Magic),
            Spirit = (byte)(lhs.Spirit - rhs.Spirit),
            Attack = (byte)(lhs.Attack - rhs.Attack),
            Defence = (byte)(lhs.Defence - rhs.Defence),
            Evade = (byte)(lhs.Evade - rhs.Evade),
            MagicDefence = (byte)(lhs.MagicDefence - rhs.MagicDefence),
            MagicEvade = (byte)(lhs.MagicEvade - rhs.MagicEvade)
        };
    }

    public static StatSet operator *(StatSet lhs, StatSet rhs)
    {
        return new StatSet()
        {
            Speed = (byte)(lhs.Speed * rhs.Speed),
            Strength = (byte)(lhs.Strength * rhs.Strength),
            Magic = (byte)(lhs.Magic * rhs.Magic),
            Spirit = (byte)(lhs.Spirit * rhs.Spirit),
            Attack = (byte)(lhs.Attack * rhs.Attack),
            Defence = (byte)(lhs.Defence * rhs.Defence),
            Evade = (byte)(lhs.Evade * rhs.Evade),
            MagicDefence = (byte)(lhs.MagicDefence * rhs.MagicDefence),
            MagicEvade = (byte)(lhs.MagicEvade * rhs.MagicEvade)
        };
    }

    public static StatSet operator /(StatSet lhs, StatSet rhs)
    {
        return new StatSet()
        {
            Speed = (byte)(lhs.Speed / rhs.Speed),
            Strength = (byte)(lhs.Strength / rhs.Strength),
            Magic = (byte)(lhs.Magic / rhs.Magic),
            Spirit = (byte)(lhs.Spirit / rhs.Spirit),
            Attack = (byte)(lhs.Attack / rhs.Attack),
            Defence = (byte)(lhs.Defence / rhs.Defence),
            Evade = (byte)(lhs.Evade / rhs.Evade),
            MagicDefence = (byte)(lhs.MagicDefence / rhs.MagicDefence),
            MagicEvade = (byte)(lhs.MagicEvade / rhs.MagicEvade)
        };
    }

    public static bool operator <(StatSet lhs, StatSet rhs)
    {
        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return false;

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
        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return false;

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
        if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            return true;

        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return false;

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
        if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            return true;

        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return false;

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
        if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            return true;

        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return false;

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
        if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
            return false;

        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return true;

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