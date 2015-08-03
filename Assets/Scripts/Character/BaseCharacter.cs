using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCharacter : MonoBehaviour
{
    const byte MAX_CHARACTER_LEVEL = 99;
    private byte level = 1;
    private byte levelUpCounter = 0;
    private uint exp = 0;
    private StatSet baseStats;
    private StatSet stats;

    public string Name
    {
        get;
        protected set;
    }

    public byte Level
    {
        get { return level; }
        protected set
        {
            if (value > MAX_CHARACTER_LEVEL)
                level = MAX_CHARACTER_LEVEL;
            else
                level = value;
        }
    }

    public uint Experience
    {
        get { return exp; }
    }

    public uint ExperienceRequiredToNextLevel
    {
        get
        {
            if (level >= MAX_CHARACTER_LEVEL)
                return 0;
            else
                return experienceMap[level + 1] - exp;
        }
    }

    public uint MaxHP
    {
        get;
        private set;
    }

    public uint MaxMP
    {
        get;
        private set;
    }

    protected StatSet BaseStats
    {
        private get { return baseStats; }
        set
        {
            if (baseStats != null)
            {
                throw new NotSupportedException("BaseStats already set.");
            }
            baseStats = value;
            stats = value;
        }
    }

    public StatSet Stats
    {
        get { return stats; }
    }

    public GearSet Gear
    {
        get;
        protected set;
    }

    public void AddExperience(uint experience)
    {
        while (level < MAX_CHARACTER_LEVEL && exp + experience > experienceMap[level])
        {
            uint difference = experienceMap[level] - exp;
            exp = experienceMap[level];
            experience -= difference;
            LevelUp();
        }
        exp += experience;
    }
    
    private void LevelUp()
    {
        if (level < MAX_CHARACTER_LEVEL)
        {
            level++;
            levelUpCounter++;
            stats += CalculateStatIncrease();
            MaxHP = CalculateHP();
            MaxMP = CalculateMP();
        }
    }

    private StatSet CalculateStatIncrease()
    {
        StatSet statIncrease = new StatSet();

        // TODO Get Gear bonus.
        byte speedBonus = 0;
        byte strengthBonus = 0;
        byte magicBonus = 0;
        byte spiritBonus = 0;

        statIncrease.Speed = (byte)((BaseStats.Speed + Math.Floor((double)(level * 1 / 10)) + Math.Floor((double)((Stats.Speed - BaseStats.Speed) / 32)) + speedBonus) - Stats.Speed);
        statIncrease.Strength = (byte)((BaseStats.Strength + Math.Floor((double)(level * 3 / 10)) + Math.Floor((double)(levelUpCounter * 3 + (Stats.Strength - BaseStats.Strength)) / 32) + strengthBonus) - Stats.Strength);
        statIncrease.Magic = (byte)((BaseStats.Magic + Math.Floor((double)(level * 3 / 10)) + Math.Floor((double)(levelUpCounter * 3 + (Stats.Magic - BaseStats.Magic)) / 32) + magicBonus) - Stats.Magic);
        statIncrease.Spirit = (byte)((BaseStats.Spirit + Math.Floor((double)(level * 3 / 20)) + Math.Floor((double)(levelUpCounter * 1 + (Stats.Spirit - BaseStats.Spirit)) / 32) + spiritBonus) - Stats.Spirit);

        return statIncrease;
    }

    private uint CalculateHP()
    {
        return (uint)Math.Floor(stats.Strength * (decimal)(hpMap[level - 1] / 50));
    }

    private uint CalculateMP()
    {
        return (uint)Math.Floor(stats.Magic * (decimal)(mpMap[level - 1] / 100));
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
        { 953529 },
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

    #region hpMap
    private List<uint> hpMap = new List<uint>
    {
        { 250 },
        { 314 },
        { 382 },
        { 454 },
        { 530 },
        { 610 },
        { 694 },
        { 782 },
        { 874 },
        { 970 },
        { 1062 },
        { 1150 },
        { 1234 },
        { 1314 },
        { 1390 },
        { 1462 },
        { 1530 },
        { 1594 },
        { 1662 },
        { 1734 },
        { 1810 },
        { 1890 },
        { 1974 },
        { 2062 },
        { 2154 },
        { 2250 },
        { 2350 },
        { 2454 },
        { 2562 },
        { 2674 },
        { 2790 },
        { 2910 },
        { 3034 },
        { 3162 },
        { 3282 },
        { 3394 },
        { 3498 },
        { 3594 },
        { 3682 },
        { 3762 },
        { 3834 },
        { 3898 },
        { 3958 },
        { 4014 },
        { 4066 },
        { 4114 },
        { 4158 },
        { 4198 },
        { 4234 },
        { 4266 },
        { 4294 },
        { 4317 },
        { 4334 },
        { 4344 },
        { 4353 },
        { 4361 },
        { 4368 },
        { 4374 },
        { 4379 },
        { 4383 },
        { 4386 },
        { 4388 },
        { 4389 },
        { 4390 },
        { 4391 },
        { 4391 },
        { 4393 },
        { 4394 },
        { 4395 },
        { 4396 },
        { 4397 },
        { 4398 },
        { 4399 },
        { 4400 },
        { 4401 },
        { 4402 },
        { 4403 },
        { 4404 },
        { 4405 },
        { 4406 },
        { 4407 },
        { 4408 },
        { 4409 },
        { 4410 },
        { 4411 },
        { 4412 },
        { 4413 },
        { 4414 },
        { 4415 },
        { 4416 },
        { 4417 },
        { 4418 },
        { 4419 },
        { 4420 },
        { 4421 },
        { 4422 },
        { 4423 },
        { 4424 },
        { 4524 }
    };
    #endregion

    #region mpMap
    private List<uint> mpMap = new List<uint>
    {
        { 200 },
        { 206 },
        { 212 },
        { 219 },
        { 226 },
        { 234 },
        { 242 },
        { 250 },
        { 259 },
        { 268 },
        { 277 },
        { 285 },
        { 293 },
        { 301 },
        { 308 },
        { 315 },
        { 321 },
        { 327 },
        { 333 },
        { 340 },
        { 347 },
        { 355 },
        { 363 },
        { 371 },
        { 380 },
        { 389 },
        { 399 },
        { 409 },
        { 419 },
        { 430 },
        { 441 },
        { 453 },
        { 465 },
        { 477 },
        { 489 },
        { 500 },
        { 510 },
        { 519 },
        { 527 },
        { 535 },
        { 542 },
        { 548 },
        { 554 },
        { 559 },
        { 564 },
        { 568 },
        { 572 },
        { 576 },
        { 579 },
        { 582 },
        { 584 },
        { 586 },
        { 587 },
        { 588 },
        { 589 },
        { 590 },
        { 591 },
        { 592 },
        { 593 },
        { 594 },
        { 595 },
        { 596 },
        { 597 },
        { 598 },
        { 599 },
        { 600 },
        { 601 },
        { 602 },
        { 603 },
        { 604 },
        { 605 },
        { 606 },
        { 607 },
        { 608 },
        { 609 },
        { 610 },
        { 611 },
        { 612 },
        { 613 },
        { 614 },
        { 615 },
        { 616 },
        { 617 },
        { 618 },
        { 619 },
        { 620 },
        { 621 },
        { 622 },
        { 623 },
        { 624 },
        { 625 },
        { 626 },
        { 627 },
        { 628 },
        { 629 },
        { 630 },
        { 631 },
        { 632 },
        { 642 }
    };
    #endregion
}