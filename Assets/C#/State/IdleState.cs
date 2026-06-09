using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    PlayerController player;
    Animator anime;
    public IdleState(PlayerController player)
    {
        this.player = player;
    }
    public void Enter()
    {
        player.anime.SetBool("isIdle", true);
        //Debug.Log("IdleState‚É“ü‚è‚Ü‚µ‚½");
    }
    public void Update()
    {
        player.anime.SetBool("isIdle", true);
    }
    public void Exit()
    {
        player.anime.SetBool("isIdle", false);
    }
}
