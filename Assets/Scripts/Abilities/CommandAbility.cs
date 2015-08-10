using System;
using System.Collections.Generic;

public abstract class CommandAbility : Ability
{
    public bool AvailableInField { get; protected set; }
    public bool AvailableInBattle { get; protected set; }
    public int MPCost { get; protected set; }

    public void Invoke(Entity invoker, Entity target) {
        if (BattleManager.BattleInProgress == true && AvailableInBattle == false)
            throw new Exception(string.Format("Ability `{0}` cannot be invoked whilst in battle", Name));

        if (BattleManager.BattleInProgress == false && AvailableInField == false)
            throw new Exception(string.Format("Ability `{0}` cannot be invoked outside of battle.", Name));

        if (BattleManager.BattleInProgress == true && AvailableInBattle == true) {
            float invokerAccuracy = CalculateAccuracy(invoker, target);

            // TODO if invoker has Accuracy+ then skip these checks..
            Random rng = new Random();
            if (rng.Next(0, 100) >= invokerAccuracy || rng.Next(0, 100) < target.Stats.Evade)
                BattleManager.ShowMessage("Attack Missed!");
            else
                InvokeInBattle(invoker, target);
        } else if (BattleManager.BattleInProgress == false && AvailableInField == true) {
            InvokeInField(invoker, target);
        }
    }

    protected abstract void InvokeInField(Entity invoker, Entity target);
    protected abstract void InvokeInBattle(Entity invoker, Entity target);

    private float CalculateAccuracy(Entity invoker, Entity target)
    {
        float accuracy = 100;

        List<StatusEffect> invokerStatusEffects = invoker.ActiveStatusEffects.FindAll(se => se == StatusEffect.Confuse || se == StatusEffect.Darkness);
        bool targetIsValished = target.ActiveStatusEffects.Contains(StatusEffect.Vanish);

        invokerStatusEffects.ForEach(_ => accuracy *= 0.5f);

        // TODO if target has DEFEND or DISTRACT

        if (targetIsValished)
            accuracy = 0;

        return accuracy;
    }
}
