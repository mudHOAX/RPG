using System.Collections.Generic;

public class EnemySet
{
    public List<BaseEnemy> Enemies { get; set; }

    public uint Gil
    {
        get
        {
            uint gil = 0;
            Enemies.ForEach(e => gil += e.Gil);
            return gil;
        }
    }
}