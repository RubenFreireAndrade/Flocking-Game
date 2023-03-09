using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : BaseState
{
    public Roaming(Flock stateMachine) : base("Roaming", stateMachine) {}

    Flock flock;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(((Flock) stateMachine).chasingState);
        }
    }
}
