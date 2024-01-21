using UnityEngine;

public class IdleEn : BaseFunctionEn
{
    public override void EnterState(EnemyStateManager enemy)
    {
       

    }
    public override void UpdaterState(EnemyStateManager enemy)
    {
        enemy.animator.SetBool("Run", false);
        float distToPlayer = Vector2.Distance(enemy.rb.position,enemy.player.position);
        if (distToPlayer <= enemy.agroDistance)
        {
            enemy.SwitchState(enemy.run);
        }
    }
    public override void FixUpdaterState(EnemyStateManager enemy)
    {
        
    }
    
    
}
