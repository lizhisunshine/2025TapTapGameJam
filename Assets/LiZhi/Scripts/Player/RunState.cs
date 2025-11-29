using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : BaseState
{
    public PlayerParamator paramator;

    public PlayerFsm fsm;

    //用于计算旋转的vec
    public Vector3 rotateVec = new Vector3();


    private Vector3 lastValidDirection = Vector3.forward;

    public RunState(PlayerFsm f)
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
                paramator.InsideRunMusic.Play();
            }
            else
            {
                paramator.OutsideRunMusic.Play();
            }
        }
        else
        {
            paramator.InsideRunMusic.Play();
        }

    }

    public override void OnUpdate()
    {
        //进入了方法输出内容
        Debug.Log("奔跑状态");
        //rotateVec = Vector3.Cross(paramator.PlayerCamera.transform.right, Vector3.up);
        //Vector3 targetDir = paramator.PlayerCamera.transform.right * Input.GetAxisRaw("Horizontal") + rotateVec * Input.GetAxisRaw("Vertical");
        //Quaternion targetRotation = Quaternion.LookRotation(targetDir, Vector3.up);
        //paramator.playerTransform.rotation = Quaternion.Lerp(paramator.playerTransform.rotation, targetRotation, paramator.rotateSpeed * Time.deltaTime);


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
        paramator.InsideRunMusic.Stop();
        paramator.OutsideRunMusic.Stop();

    }
}
