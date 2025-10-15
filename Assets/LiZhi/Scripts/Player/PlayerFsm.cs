using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FsmParamator
{
    public E_PlayerState CurrentEState;
}

public class PlayerFsm
{

    //建立枚举和类型的对应关系
    public Dictionary<E_PlayerState,BaseState> FsmDic;
    //保存目前的信息
    public FsmParamator paramator;
    //当前正在使用的状态
    public BaseState CurrentState;
    public PlayerFsm(FsmParamator p)
    {
        paramator = p;
        FsmDic = new Dictionary<E_PlayerState,BaseState>();
    }

    public void AddState(E_PlayerState Estate,BaseState state)
    {
        //检测是否已经添加了
        if (!FsmDic.ContainsKey(Estate))
        { 
            FsmDic.Add(Estate, state);
        }
    }

    public void SwitchState(E_PlayerState Estate) 
    {
        //检测是否已经添加
        if (!FsmDic.ContainsKey(Estate))
        {
            return;
        }
        //检测当前是否有状态
        if (CurrentState != null)
        {
            CurrentState.OnExit();
        }

        paramator.CurrentEState = Estate;
        CurrentState = FsmDic[Estate];
        FsmDic[Estate].OnEnter();

    }

    public void OnUpdate() 
    {
        CurrentState?.OnUpdate();
    }
}
