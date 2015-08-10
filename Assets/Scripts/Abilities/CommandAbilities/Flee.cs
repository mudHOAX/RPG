using System;

public sealed class Flee : CommandAbility
{
    private const float GIL_LOSS_RATE = 0.1f;

    public Flee()
    {
        Id = 2;
        Name = "Flee";
        Description = "Escape from battle with high probability.";

        AvailableInBattle = true;
        AvailableInField = false;
    }

    protected override void InvokeInBattle(Entity invoker, Entity target)
    {
        if (BattleManager.CurrentBattle.CanFlee)
        {
            uint droppedGil = (uint)Math.Round((BattleManager.CurrentBattle.EnemySet.Gil / (1 + GIL_LOSS_RATE)));
            PlayerManager.TryReduceGil(droppedGil, out droppedGil);
            BattleManager.ShowMessage("Dropped {0} Gil!", droppedGil);
            BattleManager.CurrentBattle.Flee();
        }
        else
            BattleManager.ShowMessage("Cannot Escape!");
    }

    protected override void InvokeInField(Entity invoker, Entity target)
    {
        throw new NotImplementedException();
    }
}