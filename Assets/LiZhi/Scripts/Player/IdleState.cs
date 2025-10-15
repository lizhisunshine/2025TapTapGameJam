using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    public PlayerParamator paramator;

    public PlayerFsm fsm;
    public IdleState(PlayerFsm f)
    {
        paramator = f.paramator as PlayerParamator;
        fsm = f;
    }

    public override void OnEnter()
    { 
    
    }
    public override void OnUpdate()
    {
        //进入了方法输出内容
        Debug.Log("闲置状态");

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                fsm.SwitchState(E_PlayerState.Run);
            }
            else 
            {
                fsm.SwitchState(E_PlayerState.Walk);
            }
        }


    }
    public override void OnExit()
    {

    }
}
