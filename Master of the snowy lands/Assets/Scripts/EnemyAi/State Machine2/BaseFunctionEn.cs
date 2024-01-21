
using UnityEngine;

public class BaseFunctionEn : EnemyFundamentState
{
    private int randomSpot;
    private float waitTime;
    
    
    public override void EnterState(EnemyStateManager enemy)
    {
        waitTime = enemy.startWaitTime;
        randomSpot = Random.Range(0, enemy.moveSpots.Length);
       // enemy.rb.simulated = true;
    }
    public override void UpdaterState(EnemyStateManager enemy)
    {
        
    }
    public override void FixUpdaterState(EnemyStateManager enemy)
    {
        
    }
    private void LookAtPlayer(EnemyStateManager enemy)
    {
        if (enemy.lookAt == true)
        {
            Vector3 flipped = enemy.transform.localScale;
            flipped.z *= -1f;
            if (enemy.transform.position.x > enemy.player.position.x && enemy.isFlipped)
            {
                enemy.transform.localScale = flipped;
                enemy.transform.Rotate(0f, 180f, 0f);
                enemy.isFlipped = false;
            }
            else if (enemy.transform.position.x < enemy.player.position.x && !enemy.isFlipped)
            {
                enemy.transform.localScale = flipped;
                enemy.transform.Rotate(0f, 180f, 0f);
                enemy.isFlipped = true;
            }
        }
    }

    public void Run(EnemyStateManager enemy)
    {
        if(enemy.rb.transform.localPosition.y < enemy.player.localPosition.y - 1.6f || enemy.rb.transform.localPosition.y > enemy.player.localPosition.y + 1.6f)
        {
             enemy.animator.SetBool("Run", false);            
        }
        else
        {
            LookAtPlayer(enemy);
            enemy.animator.SetBool("Run", true);            
            var step = enemy.speedRun * Time.fixedDeltaTime;
            Vector2 target = new Vector2(enemy.player.position.x, enemy.rb.position.y);
            enemy.rb.transform.position = Vector2.MoveTowards(enemy.rb.position, target, step);
        }
    }
    public void Patrol(EnemyStateManager enemy)
    {       
        enemy.animator.SetBool("Run", true);
        PatrolTurn(enemy);
        var step = enemy.speedRun * Time.fixedDeltaTime;                      
        enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, enemy.moveSpots[randomSpot].position, step);                
        if (Vector2.Distance(enemy.transform.position, enemy.moveSpots[randomSpot].position) < 1f)
        {
            enemy.animator.SetBool("Run", false);
            if (waitTime <= 0)
            {

                randomSpot = Random.Range(0, enemy.moveSpots.Length);
                waitTime = enemy.startWaitTime;
            }
            else
            {

                waitTime -= Time.deltaTime;
            }
        }
    }
    private void PatrolTurn(EnemyStateManager enemy)
    {
        Vector3 flipped = enemy.transform.localScale;
        flipped.x *= -1f;
        if (enemy.transform.position.x > enemy.moveSpots[randomSpot].position.x && enemy.isFlipped)
        {
            enemy.transform.localScale = flipped;
            enemy.isFlipped = false;
        }
        else if (enemy.transform.position.x < enemy.moveSpots[randomSpot].position.x && !enemy.isFlipped)
        {
            enemy.transform.localScale = flipped;
            enemy.isFlipped = true;
        }
    }
    public void AttackEnemy(EnemyStateManager enemy)
    {
        LookAtPlayer(enemy);
        enemy.animator.SetBool("Run", false);
        enemy.animator.SetBool("Attack",true);
        

    }
    



}
