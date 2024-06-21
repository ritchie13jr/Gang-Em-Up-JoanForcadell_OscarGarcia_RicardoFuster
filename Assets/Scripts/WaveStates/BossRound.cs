using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRound : BaseState
{
    private float timeToStart = 1f;
    private float elapsedTime;
    GameObject boss;
    private int counter;

    public BossRound(WaveSM stateMachine) : base("BossRound", stateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        counter = 0;
    }
    public override void Update()
    {
        base.Update();
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeToStart && counter == 0) 
        {
            Debug.Log("Boss Spawned");
            PoolManager.Instance.GimmeMyBoss();          
            counter++;
        }
    }
    public override void Exit()
    {
        base.Exit();

    }
}
