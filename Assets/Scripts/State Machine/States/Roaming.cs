using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : BaseState
{
    public Roaming(FlockManager stateMachine) : base("Roaming", stateMachine) {}

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(((FlockManager) stateMachine).chasingState);
        }
    }
}
