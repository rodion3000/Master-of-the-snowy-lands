using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEntryState : State
{ 
    private CharacterController2D Controller;
    public bool attack;
    public override void OnEnter(StateMachine _stateMachine)
    {        
        base.OnEnter(_stateMachine);
        Controller = GetComponent<CharacterController2D>();       
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
        if (Controller.m_Grounded == true)
        {
            State nextState = (State)new GroundEntryState();
            stateMachine.SetNextState(nextState);
        }
    }
}
