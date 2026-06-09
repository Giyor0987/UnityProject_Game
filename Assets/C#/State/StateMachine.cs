using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private IState currentState;

    public void ChangeState(IState newState)
    {
        if (newState == null) return;

        // 既に同じインスタンスなら何もしない
        if (currentState == newState) return;

        // 既存状態があれば Exit を呼ぶ
        if (currentState != null)
            currentState.Exit();

        currentState = newState;

        // 新状態の Enter を呼ぶ
        currentState.Enter();
    }

    public void Update()
    {
        // currentState が null の可能性をチェック
        if (currentState != null)
            currentState.Update();
    }
}
