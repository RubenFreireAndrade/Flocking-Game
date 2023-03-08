using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseState : MonoBehaviour
{
    public string stateName;
    protected StateMachine stateMachine;

    public BaseState(string name, StateMachine stateMachine )
    {
        this.stateName = name;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter() {}
    public virtual void Update() {}
    public virtual void Exit() {}
}
