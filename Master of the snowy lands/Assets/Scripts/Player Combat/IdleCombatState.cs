using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class IdleCombatState : State
{
    protected Rigidbody2D rb;
    protected PlayMovement playMovement;

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        rb = GetComponent<Rigidbody2D>();
        playMovement = GetComponent<PlayMovement>();
        rb.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;

    }




}
