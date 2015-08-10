using System;

public sealed class AttackAbility : CommandAbility
{
    public AttackAbility()
    {
        Id = 1;
        Name = "Attack";
        Description = "Attack with equipped weapon.";

        AvailableInBattle = true;
        AvailableInField = false;
    }

    protected override void InvokeInBattle(Entity invoker, Entity target)
    {
        BattleManager.CurrentBattle.CalculateAttackDamage(invoker, target);
    }

    protected override void InvokeInField(Entity invoker, Entity target)
    {
        throw new NotImplementedException();
    }
}