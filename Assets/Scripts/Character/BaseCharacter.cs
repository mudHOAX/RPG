public abstract class BaseCharacter
{
    const byte MAX_CHARACTER_LEVEL = 99;
    private byte level;

    public string Name
    {
        get;
        set;
    }

    public byte Level
    {
        get { return level; }
        set {
            if (value > MAX_CHARACTER_LEVEL)
                level = MAX_CHARACTER_LEVEL;
            else
                level = value; 
        }
    }

    public uint MaxHP
    {
        get;
        set;
    }

    public uint MaxMP
    {
        get;
        set;
    }

    public StatSet Stats
    {
        get;
        set;
    }

    public GearSet Gear
    {
        get;
        set;
    }
}