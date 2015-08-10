using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected const byte MAX_LEVEL = 99;
    private byte level = 1;
    private uint exp = 0;
    private uint maxHP = 0;
    private uint maxMP = 0;
    private uint currentHP = 0;
    private uint currentMP = 0;
    private StatSet stats = new StatSet();
    private GearSet gear = new GearSet();
    private List<StatusEffect> activeStatusEffects = new List<StatusEffect>();
    private List<CommandAbility> commandAbilities = new List<CommandAbility>();
    private List<StatusEffect> statusImmunities = new List<StatusEffect>();
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

    public string Name { get; protected set; }

    public virtual byte Level
    {
        get { return level; }
        protected set { level = (value > MAX_LEVEL) ? MAX_LEVEL : value; }
    }

    public virtual uint Experience
    {
        get { return exp; }
        protected set { exp = value; }
    }

    public virtual uint MaxHP
    {
        get { return maxHP; }
        protected set { maxHP = value; }
    }

    public virtual uint MaxMP
    {
        get { return maxMP; }
        protected set { maxMP = value; }
    }

    public virtual uint CurrentHP
    {
        get { return currentHP; }
        protected set { currentHP = (value > MaxHP) ? MaxHP : value; }
    }

    public virtual uint CurrentMP {
        get { return currentMP; }
        protected set { currentMP = (value > MaxMP) ? MaxMP : value; }
    }

    public virtual StatSet Stats
    {
        get { return stats; }
        protected set { stats = value; }
    }

    public virtual GearSet Gear
    {
        get { return gear; }
        protected set { gear = value; }
    }

    public virtual List<StatusEffect> ActiveStatusEffects
    {
        get { return activeStatusEffects; }
        protected set { activeStatusEffects = value; }
    }

    public virtual List<CommandAbility> CommandAbilities
    {
        get { return commandAbilities; }
        protected set { commandAbilities = value; }
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

    public void IncreaseCurrentHP(uint hp)
    {
        if (ActiveStatusEffects.Contains(StatusEffect.KO))
            return;

        CurrentHP += hp;
        if (CurrentHP == 0)
            AddStatusEffect(StatusEffect.KO);
    }

    public void ReduceCurrentHP(uint hp)
    {
        CurrentHP -= hp;
        if (CurrentHP == 0)
            AddStatusEffect(StatusEffect.KO);
    }

    public void IncreaseCurrentMP(uint mp)
    {
        CurrentMP += mp;
    }

    public void ReduceCurrentMP(uint mp)
    {
        CurrentMP -= mp;
    }

    public void AddStatusEffect(StatusEffect statusEffect)
    {
        // TODO StatusEffects wear off..
        if (!activeStatusEffects.Contains(statusEffect))
            activeStatusEffects.Add(statusEffect);
    }

    public void RemoveStatusEffect(StatusEffect statusEffect)
    {
        if (activeStatusEffects.Contains(statusEffect))
            activeStatusEffects.Remove(statusEffect);
    }

    public abstract CommandAbility GetMove();
}