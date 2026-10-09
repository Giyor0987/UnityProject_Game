using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootState :IState
{
    PlayerController player;
    Animator anime;
    public ShootState(PlayerController player)
    {
        this.player = player;
        anime = player.anime;
    }
    public void Enter()
    {
        //Debug.Log("ShotStateÇ…ì¸ÇËÇ‹ÇµÇΩ");
        anime.SetBool("isShoot", true);
    }
    public void Update()
    {
        //Debug.Log("ShotStateÇÃUpdate");
        anime.SetBool("isShoot", true);
    }
    public void Exit()
    {
        //Debug.Log("ShotStateÇ©ÇÁèoÇ‹ÇµÇΩ");
        anime.SetBool("isShoot", false);
    }
}
