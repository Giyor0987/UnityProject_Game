using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState : IState
{
    private PlayerController player;

    public DieState(PlayerController player)
    {
        this.player = player;
    }

    public void Enter()
    {
        Debug.Log("you are dead");
    }
    public void Update()
    {
        
    }   
    public void Exit()
    {

    }
}
