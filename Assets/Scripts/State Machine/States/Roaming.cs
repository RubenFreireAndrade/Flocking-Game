using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roaming : BaseState
{
    public Roaming(Flock stateMachine) : base("Roaming", stateMachine) {}

    //private float input;

    public override void Enter()
    {
        base.Enter();
        //input = 0f;
    }

    public override void Update()
    {
        base.Update();
        //input = Input.GetAxis("Horizontal");
        // If player has been spawned. transition state to Chasing.
        if (Input.GetKeyDown(KeyCode.E)) stateMachine.ChangeState(((Flock) stateMachine).chasingState);
    }
}
