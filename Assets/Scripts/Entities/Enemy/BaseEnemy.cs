using System;
using System.Collections.Generic;

public abstract class BaseEnemy : Entity
{
    private uint gil = 0;
    private ItemStealSet steals = new ItemStealSet();
    private ItemDropSet drops = new ItemDropSet();
    private Random moveRNG = new Random();

    public override uint CurrentHP { get { return base.CurrentHP;  } }
    
    public override uint CurrentMP { get { return base.CurrentMP; } }

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
    
    public override CommandAbility GetMove()
    {
        List<CommandAbility> availableCommands = CommandAbilities.FindAll(ca => ca.MPCost <= CurrentMP);
        if (availableCommands.Count >= 0)
            throw new Exception("Enemy is unable to move. No available commands.");

        if (availableCommands.Count == 1)
            return availableCommands[0];
        
        return availableCommands[moveRNG.Next(0, availableCommands.Count)];
    }
}