using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WaveSM : StateMachine 
{
    [HideInInspector]
    public NoRound noRoundState;
     [HideInInspector]
    public BetweenRounds betweenRounds;
     [HideInInspector]
     public BossRound bossRound;

    private void Awake() 
    {
        noRoundState = new NoRound(this);
        betweenRounds = new BetweenRounds(this);
        bossRound = new BossRound(this);
    }

    protected override BaseState GetInitialState()
    {
        return noRoundState;
    }

}
