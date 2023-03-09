using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : BaseState
{
    public Chasing(Flock stateMachine) : base("Chasing", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        // If player has been spawned. transition state to Chasing.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(((Flock) stateMachine).roamingState);
        }
    }
}
