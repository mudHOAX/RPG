using System;
using System.Collections.Generic;

public class BaseCharacter : Entity
{
    private byte levelUpCounter = 0;
    private StatSet baseStats = new StatSet();

    public override byte Level
    {
        get { return base.Level; }
        protected set
        {
            base.Level = (value > MAX_LEVEL) ? MAX_LEVEL : value;
            base.Experience = experienceMap[base.Level];
        }
    }

    public override uint Experience { get { return base.Experience; } }

    public uint ExperienceRequiredToNextLevel { get { return (Level >= MAX_LEVEL) ? 0 : experienceMap[Level + 1] - Experience; } }
    
    public override uint MaxHP { get { return base.MaxHP; } }

    public override uint MaxMP { get { return base.MaxMP; } }

    public override uint CurrentHP { get { return base.CurrentHP; } }

    public override uint CurrentMP { get { return base.CurrentMP; } }

    protected StatSet BaseStats
    {
        private get { return baseStats; }
        set
        {
            baseStats = value;
            base.Stats = value + Gear.Stats;
        }
    }

    public override StatSet Stats { get { return base.Stats; } }

    public override GearSet Gear
    {
        get { return base.Gear; }
        protected set
        {
            base.Gear = value;
            base.Stats += Gear.Stats;
        }
    }

    public override List<StatusEffect> ActiveStatusEffects { get { return base.ActiveStatusEffects; } }

    public void Equip(Weapon weapon)
    {
        if (Gear.Weapon != null)
            base.Stats -= Gear.Weapon.Stats;

        Gear.Weapon = weapon;
        base.Stats += Gear.Weapon.Stats;
    }

    public void Equip(Armour armour)
    {
        switch (armour.Type)
        {
            case ArmourType.Hat:
            case ArmourType.Helmet:
                if (Gear.Head != null)
                    base.Stats -= Gear.Head.Stats;

                Gear.Head = armour;
                base.Stats += Gear.Head.Stats;
                break;
            case ArmourType.Armlet:
            case ArmourType.Gauntlet:
                if (Gear.Arm != null)
                    base.Stats -= Gear.Arm.Stats;

                Gear.Arm = armour;
                base.Stats += Gear.Arm.Stats;
                break;
            case ArmourType.LightArmour:
            case ArmourType.HeavyArmour:
            case ArmourType.Robe:
                if (Gear.Body != null)
                    base.Stats -= Gear.Body.Stats;

                Gear.Body = armour;
                base.Stats += Gear.Body.Stats;
                break;
            case ArmourType.AddOn:
                if (Gear.AddOn != null)
                    base.Stats -= Gear.AddOn.Stats;

                Gear.AddOn = armour;
                base.Stats += Gear.AddOn.Stats;
                break;
        }
    }

    public void AddExperience(uint experience)
    {
        while (Level < MAX_LEVEL && Experience + experience > experienceMap[Level])
        {
            uint difference = experienceMap[Level] - Experience;
            experience -= difference;
            LevelUp();
        }
        base.Experience += experience;
    }

    private void LevelUp()
    {
        if (Level > MAX_LEVEL)
            return;

        Level++;
        levelUpCounter++;
        base.Stats += CalculateStatIncrease();
        base.MaxHP = CalculateHP();
        base.MaxMP = CalculateMP();
    }

    private StatSet CalculateStatIncrease()
    {
        StatSet statIncrease = new StatSet();
        StatSet gearBonus = Gear.Weapon.Stats + Gear.Head.Stats + Gear.Arm.Stats + Gear.Body.Stats + Gear.AddOn.Stats;

        int speedBonus = gearBonus.Speed;
        int strengthBonus = gearBonus.Strength;
        int magicBonus = gearBonus.Magic;
        int spiritBonus = gearBonus.Spirit;

        statIncrease.Speed = (byte)((BaseStats.Speed + Math.Floor((double)(Level * 1 / 10)) + Math.Floor((double)((Stats.Speed - BaseStats.Speed) / 32)) + speedBonus) - Stats.Speed);
        statIncrease.Strength = (byte)((BaseStats.Strength + Math.Floor((double)(Level * 3 / 10)) + Math.Floor((double)(levelUpCounter * 3 + (Stats.Strength - BaseStats.Strength)) / 32) + strengthBonus) - Stats.Strength);
        statIncrease.Magic = (byte)((BaseStats.Magic + Math.Floor((double)(Level * 3 / 10)) + Math.Floor((double)(levelUpCounter * 3 + (Stats.Magic - BaseStats.Magic)) / 32) + magicBonus) - Stats.Magic);
        statIncrease.Spirit = (byte)((BaseStats.Spirit + Math.Floor((double)(Level * 3 / 20)) + Math.Floor((double)(levelUpCounter * 1 + (Stats.Spirit - BaseStats.Spirit)) / 32) + spiritBonus) - Stats.Spirit);

        return statIncrease;
    }

    private uint CalculateHP()
    {
        return (uint)Math.Floor(Stats.Strength * (decimal)(hpMap[Level - 1] / 50));
    }

    private uint CalculateMP()
    {
        return (uint)Math.Floor(Stats.Magic * (decimal)(mpMap[Level - 1] / 100));
    }

    public override CommandAbility GetMove()
    {
        throw new NotImplementedException();
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