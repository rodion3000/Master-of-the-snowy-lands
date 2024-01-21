using System;
using System.Collections;
using UnityEngine;

public class AttackEn : BaseFunctionEn
{
    public override void EnterState(EnemyStateManager enemy)
    {
        base.EnterState(enemy);
       // enemy.rb.simulated = false;
    }
    public override void UpdaterState(EnemyStateManager enemy)
    {
        base.UpdaterState(enemy);
        float distToPlayer = Vector2.Distance(enemy.rb.position, enemy.player.position);
        if (distToPlayer >= enemy.attackDistance && enemy.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {          
                enemy.animator.SetBool("Attack", false);
                enemy.SwitchState(enemy.run);
               //  enemy.StartCoroutine(WaitRun(enemy));                
        }

    }
    public override void FixUpdaterState(EnemyStateManager enemy)
    {

        //TouchDamage(enemy);
        base.FixUpdaterState(enemy);
        AttackEnemy(enemy);
    }
   private IEnumerator WaitRun(EnemyStateManager enemy)
    {
        yield return new WaitForSeconds(0f);
        enemy.animator.SetBool("Attack", false);
        enemy.SwitchState(enemy.run);
    }

   // private void TouchDamage(EnemyStateManager enemy)
  //  {
       // Vector3 dir = (enemy.player.transform.position - enemy.rb.transform.position).normalized;
        //Collider2D touch = Physics2D.OverlapCircle(enemy.touchPoint.position, enemy.touchPointRange, enemy.playerLayers);
       // if (touch != null)
      //  {
        //    touch.GetComponent<PlayerHealth>().TakeDamage(1);
            //enemy.playerRigibody.AddForce(dir * 2f * 2f, ForceMode2D.Impulse);
      // }

   // }
    

     

}
