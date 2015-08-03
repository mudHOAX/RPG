using System.Collections.Generic;

public abstract class BaseCharacter
{
    const byte MAX_CHARACTER_LEVEL = 99;
    private byte level;
    private uint exp;
    private StatSet stats;

    public string Name
    {
        get;
        set;
    }

    public byte Level
    {
        get { return level; }
    }

    public uint Experience
    {
        get { return exp; }
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
        get { return stats; }
    }

    public GearSet Gear
    {
        get;
        set;
    }

    public void AddExperience(uint experience)
    {
        exp += experience;
        while (experience > 0)
        {
            exp++;
            if (level < MAX_CHARACTER_LEVEL && exp >= experienceMap[level + 1])
                LevelUp();
            experience--;
        }
    }

    protected abstract StatSet OnLevelUpStatIncrease(byte level);

    private void LevelUp()
    {
        if (level < MAX_CHARACTER_LEVEL)
        {
            level++;
            StatSet increasedStats = OnLevelUpStatIncrease(level);
            stats += increasedStats;
        }
    }

    #region experienceMap
    private List<uint> experienceMap = new List<uint>
    {
        { 0 },
        { 16 },
        { 47 },
        { 101 },
        { 186 },
        { 314 },
        { 496 },
        { 746 },
        { 1078 },
        { 1510 },
        { 2059 },
        { 2745 },
        { 3588 },
        { 4612 },
        { 5840 },
        { 7298 },
        { 9012 },
        { 11012 },
        { 13327 },
        { 15989 },
        { 19030 },
        { 22486 },
        { 30786 },
        { 35706 },
        { 41194 },
        { 47291 },
        { 54041 },
        { 61488 },
        { 69680 },
        { 78664 },
        { 88490 },
        { 99208 },
        { 110872 },
        { 123535 },
        { 137233 },
        { 152082 },
        { 168082 },
        { 185312 },
        { 203834 },
        { 223710 },
        { 244006 },
        { 267787 },
        { 292121 },
        { 318076 },
        { 344724 },
        { 375136 },
        { 406386 },
        { 439548 },
        { 474700 },
        { 511919 },
        { 551285 },
        { 592878 },
        { 636782 },
        { 683080 },
        { 731858 },
        { 783202 },
        { 837202 },
        { 893947 },
        { 853529 },
        { 1016040 },
        { 1081576 },
        { 1150232 },
        { 1222106 },
        { 1297296 },
        { 1375904 },
        { 1458031 },
        { 1543781 },
        { 1633258 },
        { 1726570 },
        { 1823824 },
        { 1925130 },
        { 2030598 },
        { 2140342 },
        { 2254475 },
        { 2373113 },
        { 2496372 },
        { 2624372 },
        { 2757232 },
        { 2895074 },
        { 3038020 },
        { 3186196 },
        { 3339727 },
        { 3498741 },
        { 3663366 },
        { 3833734 },
        { 4009976 },
        { 4192226 },
        { 4380618 },
        { 4575290 },
        { 4776379 },
        { 4984025 },
        { 5198368 },
        { 5419552 },
        { 5647720 },
        { 5883018 },
        { 6125592 },
        { 6375592 },
        { 6633167 }
    };
    #endregion
}