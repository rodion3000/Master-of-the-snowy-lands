using UnityEngine;

public class ChoiceEn : BaseFunctionEn
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Physics2D.IgnoreLayerCollision(6, 6, true);
        Physics2D.IgnoreLayerCollision(6, 3, true);
        Physics2D.IgnoreLayerCollision(6, 8, true);
    }
    public override void UpdaterState(EnemyStateManager enemy)
    {
        if (enemy.idleEnemy == true)
        {
            enemy.SwitchState(enemy.idle);
        }
        if(enemy.patrolEnemy == true)
        {
            enemy.SwitchState(enemy.patrol);
        }
        if(enemy.pillarEnemy == true)
        {
            enemy.SwitchState(enemy.pillar);
        }
    }
    public override void FixUpdaterState(EnemyStateManager enemy)
    {
        
    }
    
}
