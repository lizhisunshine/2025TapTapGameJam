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


    private Vector3 lastValidDirection = Vector3.forward;

    public WalkState(PlayerFsm f) 
    {
        paramator = f.paramator as PlayerParamator;
        fsm = f;
    }

    public override void OnEnter()
    {
        //paramator.InsidewalkMusic.Play();
        if (paramator.CenterPointControler.GetComponent<DisslutionCenter1>().target != null)
        {
            if (Vector3.Distance(paramator.CenterPointControler.GetComponent<DisslutionCenter1>().target.position, paramator.playerTransform.position)
                >= paramator.CenterPointControler.GetComponent<DisslutionCenter1>().distance)
            {
                paramator.InsidewalkMusic.Play();
            }
            else
            {
                paramator.OutsidewalkMusic.Play();
            }
        }
        else 
        {
            paramator.InsidewalkMusic.Play();
        }


    }

    public override void OnUpdate()
    {
        //进入了方法输出内容
        Debug.Log("行走状态");
        
        //人物旋转逻辑
        //rotateVec = Vector3.Cross(paramator.PlayerCamera.transform.right, Vector3.up);
        //Vector3 targetDir = paramator.PlayerCamera.transform.right * Input.GetAxisRaw("Horizontal") + rotateVec * Input.GetAxisRaw("Vertical");
        //Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
        //paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, targetRotation, paramator.rotateSpeed * Time.deltaTime);

        
        // 修改后的旋转逻辑
        rotateVec = Vector3.Cross(paramator.PlayerCamera.transform.right, Vector3.up);
        Vector3 targetDir = paramator.PlayerCamera.transform.right * Input.GetAxisRaw("Horizontal") + rotateVec * Input.GetAxisRaw("Vertical");
        // 如果有输入，更新记忆的方向
        if (targetDir.sqrMagnitude > 0.01f)
        {
        lastValidDirection = targetDir;
        }
        // 使用记忆的方向进行旋转（即使当前没有输入）
        Quaternion targetRotation = Quaternion.LookRotation(lastValidDirection, Vector3.up);
        paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, targetRotation, paramator.rotateSpeed * Time.deltaTime);


        //移动逻辑
        //paramator.rb.velocity = targetDir*paramator.moveSpeed;

        //切换idle
        //if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
        //{
        //    fsm.SwitchState(E_PlayerState.Idle);
        //}
        ////切换run
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    fsm.SwitchState(E_PlayerState.Run);
        //}

    }

    public override void OnExit()
    {
        paramator.InsidewalkMusic.Stop();
        paramator.OutsidewalkMusic.Stop();
    }
}
