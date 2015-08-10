using System.Collections.Generic;

public class MaskedMan : BaseEnemy
{ 
    public MaskedMan()
    {
        Name = "Masked Man";
        MaxHP = 188;
        MaxMP = 223;
        Stats = new StatSet
        {
            Strength = 9,
            Defence = 10,
            Evade = 2,
            Magic = 8,
            MagicDefence = 10,
            MagicEvade = 3,
            Attack = 8,
            Spirit = 10,
            Speed = 19
        };

        Steals = new ItemStealSet
        {
            Common = ItemManager.Consumables.GetById(1),
            Uncommon = ItemManager.Armours.GetById(29),
            Rare = ItemManager.Weapons.GetById(2)
        };

        StatusImmunities = new List<StatusEffect>
        {
            { StatusEffect.Berserk },
            { StatusEffect.Confuse },
            { StatusEffect.Darkness },
            { StatusEffect.Death },
            { StatusEffect.Doom },
            { StatusEffect.Float },
            { StatusEffect.Freeze },
            { StatusEffect.Haste },
            { StatusEffect.Heat },
            { StatusEffect.Mini },
            { StatusEffect.Petrify },
            { StatusEffect.Poison },
            { StatusEffect.Protect },
            { StatusEffect.Reflect },
            { StatusEffect.Regen },
            { StatusEffect.Shell },
            { StatusEffect.Silence },
            { StatusEffect.Sleep },
            { StatusEffect.Slow },
            { StatusEffect.Stop },
            { StatusEffect.Trouble },
            { StatusEffect.Vanish },
            { StatusEffect.Venom }
        };

        CommandAbilities = new List<CommandAbility>
        {
            { new AttackAbility() }
        };
    }
}