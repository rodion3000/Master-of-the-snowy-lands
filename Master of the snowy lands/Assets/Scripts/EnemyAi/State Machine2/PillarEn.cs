
using UnityEngine;

public class PillarEn : BaseFunctionEn
{
    public override void EnterState(EnemyStateManager enemy)
    {
        base.EnterState(enemy);
    }
    public override void UpdaterState(EnemyStateManager enemy)
    {
        base.UpdaterState(enemy);
        float distToPlayer = Vector2.Distance(enemy.rb.position, enemy.player.position);
        if (distToPlayer <= enemy.attackDistance)
        {
            enemy.SwitchState(enemy.attacked);
            
        }
    }
    public override void FixUpdaterState(EnemyStateManager enemy)
    {
        base.FixUpdaterState(enemy);
    }
}
