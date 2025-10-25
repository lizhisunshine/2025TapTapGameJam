using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerParamator:FsmParamator
{
    //行走 奔跑参数
    public float moveSpeed;
    public float rotateSpeed;
    public float runSpeed;
    public AudioSource walkMusic;

    //其它
    public Camera PlayerCamera;
    public Rigidbody rb;
    public Transform playerTransform;
}


public class PlayerController : MonoBehaviour
{
    public PlayerParamator P = new PlayerParamator();

    PlayerFsm fsm;

    public PlayerController()
    { 
        //用玩家属性初始化这个状态机
        fsm = new PlayerFsm(P);
        
        //添加状态
        fsm.AddState(E_PlayerState.Walk, new WalkState(fsm));
        fsm.AddState(E_PlayerState.Run, new RunState(fsm));
        fsm.AddState(E_PlayerState.Idle, new IdleState(fsm));
        //初始化玩家状态
        fsm.SwitchState(E_PlayerState.Idle);
    }
    // Update is called once per frame

    private void Start()
    {
        //与上面的初始化不同的是，transform只能在生命周期函数中初始化
        //初始化成功在控制台输出内容
        print("11");

    }
    void Update()
    {
        fsm.OnUpdate();
    }
}
