using UnityEngine;

public class RunEn : BaseFunctionEn
{
    public override void EnterState(EnemyStateManager enemy)
    {
        
    }
    public override void UpdaterState(EnemyStateManager enemy)
    {
        StopRun(enemy);
        float distToPlayer = Vector2.Distance(enemy.rb.position, enemy.player.position);
        if(distToPlayer > enemy.agroDistance + 2f)
        {
            enemy.SwitchState(enemy.choice);
        }
        if(distToPlayer <= enemy.attackDistance)
        {
            enemy.SwitchState(enemy.attacked);
        }
        
    }
    public override void FixUpdaterState(EnemyStateManager enemy)
    {
         Run(enemy); 
       
    }
    private void StopRun(EnemyStateManager enemy)
    {
        Collider2D[] stop = Physics2D.OverlapCircleAll(enemy.stopRunCollider.position, enemy.stopRange, enemy.tileLayer);
        foreach (Collider2D tile in stop)
        {
            if (tile != null)
            {
                enemy.animator.SetBool("Run", false);
            }
        }

    }



}
    

