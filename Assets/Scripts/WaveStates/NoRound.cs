using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NoRound : BaseState
{
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

        if (Input.GetKeyDown(KeyCode.K))
        {
            stateMachine.ChangeState(((WaveSM)stateMachine).betweenRounds);
        }
    }
    public override void Exit()
    {
        base.Exit();

    }
}
