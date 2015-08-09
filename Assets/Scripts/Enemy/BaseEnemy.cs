using System;
using System.Collections.Generic;

public abstract class BaseEnemy
{
    private const byte MAX_ENEMY_LEVEL = 99;

    private byte level = 1;
    private uint maxHP = 100;
    private uint currentHP = 100;
    private uint maxMP = 50;
    private uint currentMP = 50;
    private StatSet stats = new StatSet();
    private uint exp = 0;
    private uint gil = 0;
    private ItemStealSet steals = new ItemStealSet();
    private ItemDropSet drops = new ItemDropSet();
    private Dictionary<Element, ElementModifier> elementalAffinities = new Dictionary<Element, ElementModifier>
    {
        { Element.Fire, ElementModifier.Normal },
        { Element.Ice, ElementModifier.Normal },
        { Element.Thunder, ElementModifier.Normal },
        { Element.Water, ElementModifier.Normal },
        { Element.Wind, ElementModifier.Normal },
        { Element.Earth, ElementModifier.Normal },
        { Element.Holy, ElementModifier.Normal },
        { Element.Shadow, ElementModifier.Normal }
    };
    private List<StatusEffect> statusImmunities = new List<StatusEffect>();
    private List<CommandAbility> commandAbilities = new List<CommandAbility>();
    private List<StatusEffect> activeStatusEffects = new List<StatusEffect>();

    private Random moveRNG = new Random();

    public string Name { get; protected set; }

    public byte Level
    {
        get { return level; }
        protected set
        {
            if (value > MAX_ENEMY_LEVEL)
                level = MAX_ENEMY_LEVEL;
            else
                level = value;
        }
    }

    public uint MaxHP
    {
        get { return maxHP; }
        protected set { maxHP = value; }
    }

    public uint MaxMP
    {
        get { return maxMP; }
        protected set { maxMP = value; }
    }

    public uint CurrentHP
    {
        get { return currentHP;  }
    }
    
    public uint CurrentMP
    {
        get { return currentMP; }
    }

    public StatSet Stats
    {
        get { return stats; }
        protected set { stats = value; }
    }

    public uint Experience
    {
        get { return exp; }
        protected set { exp = value; }
    }

    public uint Gil
    {
        get { return gil; }
        protected set { gil = value; }
    }

    public ItemStealSet Steals
    {
        get { return steals; }
        protected set { steals = value; }
    }

    public ItemDropSet Drops
    {
        get { return drops; }
        protected set { drops = value; }
    }

    public Dictionary<Element, ElementModifier> ElementalAffinities
    {
        get { return elementalAffinities; }
        protected set { elementalAffinities = value; }
    }

    public List<StatusEffect> StatusImmunities
    {
        get { return statusImmunities; }
        protected set { statusImmunities = value; }
    }

    public List<CommandAbility> CommandAbilities
    {
        get { return commandAbilities; }
        protected set { commandAbilities = value; }
    }

    public List<StatusEffect> ActiveStatusEffects
    {
        get { return activeStatusEffects; }
    }

    public void ReduceCurrentHP(uint hpDamage)
    {
        if (hpDamage >= currentHP)
        {
            currentHP = 0;
            throw new NotImplementedException(); // Enemy KO...
        }
        else
            currentHP -= hpDamage;
    }

    protected virtual CommandAbility GetMove()
    {
        List<CommandAbility> availableCommands = CommandAbilities.FindAll(ca => ca.MPCost <= CurrentMP);
        if (availableCommands.Count >= 0)
            throw new Exception("Enemy is unable to move. No available commands.");

        if (availableCommands.Count == 1)
            return availableCommands[0];
        
        return availableCommands[moveRNG.Next(0, availableCommands.Count)];
    }
}