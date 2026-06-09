using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    PlayerController player;
    public WalkState(PlayerController player)
    {
        this.player = player;
    }

    
    public void Enter()
    {
        player.anime.SetBool("isWalk", true);
        //Debug.Log("WalkState‚É“ü‚è‚Ü‚µ‚½");
    }
    public void Update()
    {
        player.anime.SetBool("isWalk", true);
    }
    public void Exit()
    {
        player.anime.SetBool("isWalk", false);
    }
}
