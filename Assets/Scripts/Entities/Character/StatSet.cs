public class StatSet
{
    const int MAX_SPEED = 50;
    const int MAX_STRENGTH = 99;
    const int MAX_MAGIC = 99;
    const int MAX_SPIRIT = 50;

    private int speed = 0;
    private int strength = 0;
    private int magic = 0;
    private int spirit = 0;

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

    public int Speed
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

    public int Strength
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

    public int Magic
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

    public int Spirit
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

    public int Attack { get; set; }

    public int Defence { get; set; }

    public int Evade { get; set; }

    public int MagicDefence { get; set; }

    public int MagicEvade { get; set; }

    public override bool Equals(object obj)
    {
        try { return this == (StatSet)obj; }
        catch { return false; }
    }

    public override int GetHashCode()
    {
        return new { Speed, Strength, Magic, Spirit, Attack, Defence, Evade, MagicDefence, MagicEvade }.GetHashCode();
    }

    public static StatSet operator +(StatSet lhs, StatSet rhs)
    {
        if (ReferenceEquals(lhs, null))
            lhs = new StatSet();

        if (ReferenceEquals(rhs, null))
            rhs = new StatSet();

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
        if (ReferenceEquals(lhs, null))
            lhs = new StatSet();

        if (ReferenceEquals(rhs, null))
            rhs = new StatSet();

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
        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return new StatSet();

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
        if (ReferenceEquals(lhs, null) || ReferenceEquals(rhs, null))
            return new StatSet();
        
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