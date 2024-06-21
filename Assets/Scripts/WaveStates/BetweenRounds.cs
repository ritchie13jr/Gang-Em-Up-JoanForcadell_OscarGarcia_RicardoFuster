using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenRounds : BaseState
{
    private float timeBetweenSpawn = 2f;
    private int enemiesPerWave;
    private int roundCount;
    public int defeatedEnemies;
    private float elapsedTime;
    private GameObject enemy;
    private int enemyCount;

    public BetweenRounds(WaveSM stateMachine) : base("BetweenRounds", stateMachine)
    {
        roundCount = 0;
        enemiesPerWave = 5;
    }
    public override void Enter()
    {
        base.Enter();
        enemyCount = 0;
        roundCount++;
    }
    public override void Update()
    {
       base.Update();
       
       if (enemyCount < enemiesPerWave)
       {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBetweenSpawn) 
        {
            enemy = PoolManager.Instance.RequestEnemy();
            elapsedTime = 0;
            enemyCount++;
        } 
       }

       if (defeatedEnemies == enemiesPerWave) { stateMachine.ChangeState(((WaveSM)stateMachine).bossRound);}
    }
    public override void Exit()
    {
        base.Exit();
    }
    public void DefeatedEnemy() 
    {
        Debug.Log("We good");
        defeatedEnemies++;
    }
}
