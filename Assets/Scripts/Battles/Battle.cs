using System;

public class Battle
{
    public bool CanFlee { get; protected set; }
    
    public EnemySet EnemySet { get; protected set; }

    public int CalculateAttackDamage(Entity attacker, Entity target)
    {
        Random rnd = new Random();
        int baseDamage = 0;
        int baseBonusDamage = 0;

        if (attacker.Gear.Weapon == null)
        {
            baseDamage = attacker.Stats.Attack - target.Stats.Defence;
            baseBonusDamage = attacker.Stats.Strength + rnd.Next(0, (int)Math.Floor((decimal)(attacker.Level + attacker.Stats.Strength) / 4));
        }
        else
            switch (attacker.Gear.Weapon.Type)
            {
                case WeaponType.Dagger:
                case WeaponType.Sword:
                case WeaponType.Staff:
                case WeaponType.Rod:
                case WeaponType.Spear:
                case WeaponType.Claw:
                case WeaponType.Flute:
                    baseDamage = attacker.Stats.Attack - target.Stats.Defence;
                    baseBonusDamage = attacker.Stats.Strength + rnd.Next(0, (int)Math.Floor((decimal)(attacker.Level + attacker.Stats.Strength) / 8));
                    break;

                case WeaponType.ThiefSword:
                case WeaponType.KnightSword:
                    if (attacker.Gear.Weapon.Id == 45)
                    {
                        // Save The Queen has a special damage calculation.
                        baseDamage = (attacker.Stats.Attack + attacker.Level) - target.Stats.Defence;
                        baseBonusDamage = attacker.Stats.Strength + rnd.Next(0, (int)Math.Floor((double)(attacker.Level + attacker.Stats.Strength) / 8));
                    }
                    else
                    {
                        baseDamage = attacker.Stats.Attack - target.Stats.Defence;
                        baseBonusDamage = (int)Math.Floor((double)(attacker.Stats.Strength + attacker.Stats.Spirit) / 2) + rnd.Next(0, (int)Math.Floor((double)(attacker.Level + attacker.Stats.Strength) / 8));
                    }
                    break;

                case WeaponType.Hammer:
                case WeaponType.Fork:
                    baseDamage = attacker.Stats.Attack - target.Stats.Defence;
                    baseBonusDamage = rnd.Next(0, attacker.Stats.Strength) + rnd.Next(0, (int)Math.Floor((double)(attacker.Level + attacker.Stats.Strength) / 8));
                    break;

                case WeaponType.Racket:
                    baseDamage = attacker.Stats.Attack - target.Stats.Defence;
                    baseBonusDamage = (int)Math.Floor((double)(attacker.Stats.Strength + attacker.Stats.Speed) / 2) + rnd.Next(0, (int)Math.Floor((double)(attacker.Level + attacker.Stats.Strength) / 8));
                    break;
            }
        
        int bonusDamage = CalculateBonus(attacker, target, baseBonusDamage);
        return baseDamage * bonusDamage;
    }

    private int CalculateBonus(Entity attacker, Entity target, int baseBonusDamage)
    {
        int bonusDamage = baseBonusDamage;

        // if attacker has Killer ability           bonusDamage = Math.Floor(bonusDamage * 1.5f);
        // if attacker has MP Attack                bonusDamage = Math.Floor(bonusDamage * 1.5f);
        // if attacker is in trance                 bonusDamage = Math.Floor(bonusDamage * 1.5f);

        // if attacker has Berserk status effect    bonusDamage = Math.Floor(bonusDamage * 1.5f);
        if (target.ActiveStatusEffects.Contains(StatusEffect.Berserk))
            bonusDamage = (int)Math.Floor(bonusDamage * 1.5f);

        // if target is Back Attacked               bonusDamage = Math.Floor(bonusDamage * 1.5f);

        // if target has Sleep status effect        bonusDamage = Math.Floor(bonusDamage * 1.5f);
        if (target.ActiveStatusEffects.Contains(StatusEffect.Sleep))
            bonusDamage = (int)Math.Floor(bonusDamage * 1.5f);

        // if target has Mini status effect         bonusDamage = Math.Floor(bonusDamage * 1.5f);
        if (target.ActiveStatusEffects.Contains(StatusEffect.Mini))
            bonusDamage = (int)Math.Floor(bonusDamage * 1.5f);

        // if critical hit                          bonusDamage = Math.Floor(bonusDamage * 2);

        // if attacker is in the Back Row           bonusDamage = Math.Floor(bonusDamage * 0.5f);
        if (attacker.BattleRow == BattleRow.Back)
            bonusDamage = (int)Math.Floor(bonusDamage * 0.5f);

        // if target has Protect status effect      bonusDamage = Math.Floor(bonusDamage * 0.5f);
        if (target.ActiveStatusEffects.Contains(StatusEffect.Protect))
            bonusDamage = (int)Math.Floor(bonusDamage * 0.5f);

        // if target is weak to Elem-Atk            bonusDamage = Math.Floor(bonusDamage * 1.5f);
        foreach (Element element in attacker.Gear.ElementAttack) // TODO Should this be only the weapon or all gear??
            if (target.ElementalAffinities.ContainsKey(element) && target.ElementalAffinities[element] == ElementModifier.Weak)
            {
                bonusDamage = (int)Math.Floor(bonusDamage * 1.5f);
                break;
            }

        // if attacker has Elem-Atk raising item    bonusDamage = Math.Floor(bonusDamage * 1.5f);
        if (attacker.Gear.ElementAttack.Count > 0)
            bonusDamage = (int)Math.Floor(bonusDamage * 1.5f);

        // if target halves Elem-Atk                bonusDamage = Math.Floor(bonusDamage * 0.5f);
        foreach (Element element in attacker.Gear.ElementAttack) // TODO Should this be only the weapon or all gear??
            if (target.ElementalAffinities.ContainsKey(element) && target.ElementalAffinities[element] == ElementModifier.Half)
            {
                bonusDamage = (int)Math.Floor(bonusDamage * 0.5f);
                break;
            }

        // if attacker has Mini status effect       bonusDamage = 1;
        if (attacker.ActiveStatusEffects.Contains(StatusEffect.Mini))
            bonusDamage = 1;

        return bonusDamage;
    }

    public void Flee()
    {
        if (CanFlee)
        {
            BattleManager.CurrentBattle = null;
            BattleManager.ShowMessage("Got away safely.");
        } 
        else
            BattleManager.ShowMessage("Cannot escape..");
    }
}