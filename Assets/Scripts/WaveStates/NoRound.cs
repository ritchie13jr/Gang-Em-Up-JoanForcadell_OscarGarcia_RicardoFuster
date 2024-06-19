using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NoRound : BaseState
{
    private float elapsedTime;
    public NoRound(WaveSM stateMachine) : base("NoRound", stateMachine)
    {
    
    }
    public override void Enter()
    {
        base.Enter();

    }
    public override void Update()
    {
        base.Update();
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 1.0f)
        {
            Debug.Log("We begin");
            stateMachine.ChangeState(((WaveSM)stateMachine).betweenRounds);
        }

    }
    public override void Exit()
    {
        base.Exit();

    }
}
