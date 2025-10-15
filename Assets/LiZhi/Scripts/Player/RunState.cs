using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public PlayerParamator paramator;

    public PlayerFsm fsm;

    //用于计算旋转的vec
    public Vector3 rotateVec = new Vector3();

    public RunState(PlayerFsm f)
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
        Debug.Log("奔跑状态");

        //if (Input.GetKey(KeyCode.W))
        //{
        //    paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, Quaternion.Euler(0, 180, 0), paramator.rotateSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, Quaternion.Euler(0, 0, 0), paramator.rotateSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, Quaternion.Euler(0, 90, 0), paramator.rotateSpeed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, Quaternion.Euler(0, 270, 0), paramator.rotateSpeed * Time.deltaTime);
        //}

        rotateVec = Vector3.Cross(paramator.PlayerCamera.transform.right, Vector3.up);
        Vector3 targetDir = paramator.PlayerCamera.transform.right * Input.GetAxisRaw("Horizontal") + rotateVec * Input.GetAxisRaw("Vertical");
        Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
        paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, targetRotation, paramator.rotateSpeed * Time.deltaTime);


        //paramator.rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal") * paramator.runSpeed, 0,Input.GetAxisRaw("Vertical") * paramator.runSpeed);
        paramator.rb.velocity = targetDir * paramator.runSpeed;

        //切换walk的方法
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            fsm.SwitchState(E_PlayerState.Walk);
        }
        //切换为idle的方法
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        {
            fsm.SwitchState(E_PlayerState.Idle);
        }

    }

    public override void OnExit()
    {
 
    }
}
