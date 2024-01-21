
using UnityEngine;

public class PatrolEn : BaseFunctionEn
{

    
    public override void EnterState(EnemyStateManager enemy)
    {
        base.EnterState(enemy);

    }
    public override void UpdaterState(EnemyStateManager enemy)
    {
        base.UpdaterState(enemy);
        float distToPlayer = Vector2.Distance(enemy.rb.position, enemy.player.position);
        if (distToPlayer <= enemy.agroDistance)
        {
            enemy.SwitchState(enemy.run);
        }
        
    }
    public override void FixUpdaterState(EnemyStateManager enemy)
    {
        base.FixUpdaterState(enemy);
        Patrol(enemy);
        
    }
    
    

}
