using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class WalkState : BaseState
{
    public PlayerParamator paramator;

    public PlayerFsm fsm;

    //用来计算旋转的vector
    public Vector3 rotateVec = new Vector3();

    public WalkState(PlayerFsm f) 
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
        Debug.Log("行走状态");
        
        //人物旋转逻辑
        rotateVec = Vector3.Cross(paramator.PlayerCamera.transform.right, Vector3.up);
        Vector3 targetDir = paramator.PlayerCamera.transform.right * Input.GetAxisRaw("Horizontal") + rotateVec * Input.GetAxisRaw("Vertical");
        Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
        paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, targetRotation, paramator.rotateSpeed * Time.deltaTime);
        
    
        
        //移动逻辑
        paramator.rb.velocity = targetDir*paramator.moveSpeed;

        //切换idle
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            fsm.SwitchState(E_PlayerState.Idle);
        }
        //切换run
        if (Input.GetKey(KeyCode.LeftShift))
        {
            fsm.SwitchState(E_PlayerState.Run);
        }

    }

    public override void OnExit()
    {

    }
}
