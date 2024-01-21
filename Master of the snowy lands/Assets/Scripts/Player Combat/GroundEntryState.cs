
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        attackIndex = 1;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
        Debug.Log("Player Attack " + attackIndex + " Fired!");
        combo = true;      
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        SoundAttack();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (fixedtime >= duration)
        {
            if (shouldCombo && combo)
            {
                stateMachine.SetNextState(new GroundComboState());
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
             
    }
}
