using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboRun : StateMachineBehaviour
{
   // Rigidbody2D rb;
    EnemyStateManager enemy;
    public float comboAttackSpeed;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       // rb = animator.GetComponent<Rigidbody2D>();
        enemy = animator.GetComponent<EnemyStateManager>();
        enemy.lookAt = false;
    }




    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 dir = (enemy.rb.transform.position - enemy.player.transform.position ).normalized;
        var dd = Vector2.Dot(enemy.rb.transform.position, enemy.player.transform.position);
        var step = comboAttackSpeed * Time.fixedDeltaTime;
        if (enemy.isFlipped == true)
        {
            Vector2 targetRight = new Vector2(enemy.player.position.x + 5f, enemy.rb.position.y);
            enemy.rb.transform.position = Vector2.MoveTowards(enemy.rb.transform.position, targetRight, step);
        }
        else
        {
            Vector2 targetLeft = new Vector2(enemy.player.position.x - 5f, enemy.rb.position.y);
            enemy.rb.transform.position = Vector2.MoveTowards(enemy.rb.transform.position, targetLeft, step);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.lookAt = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
