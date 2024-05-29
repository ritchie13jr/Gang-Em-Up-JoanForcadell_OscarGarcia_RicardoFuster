using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenRounds : BaseState
{
    private float timeBetweenRounds =3f;
    private float timeBetweenSpawn = 2f;
    private int enemiesPerWave;
    private int roundCount;
    private int defeatedEnemies;
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
        if (roundCount == 2) { stateMachine.ChangeState(((WaveSM)stateMachine).bossRound); }
    }
    public override void Update()
    {
       base.Update();
       
       roundCount++;
       
       if (enemyCount < enemiesPerWave)
       {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= timeBetweenSpawn) 
        {
            GameObject enemy = PoolManager.Instance.RequestEnemy();
            elapsedTime = 0;

            // en enemy hay que inicializar todos sus metodos o atributos
            // y tambien en enemy SetInactive
            enemyCount++;
        } 
       }
    }
    public override void Exit()
    {
        base.Exit();
        enemiesPerWave += 5;
    }
}
