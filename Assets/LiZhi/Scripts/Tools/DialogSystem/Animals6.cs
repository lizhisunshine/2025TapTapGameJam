using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals6 : AnimalsBase
{
    public DialogSystem dialogSystem;
    public void Start()
    {
        TalkNum = 2;
        this.gameObject.GetComponent<Peal>().talkNum = TalkNum;
    }
    public void Update()
    {
        if (TalkNum <= 0)
        {
            TalkNum = 0;
        }
        //if (Vector3.Distance(this.gameObject.transform.position, this.GetComponent<Peal>().player.transform.position) >= dialogSystem.maxDistance)
        //{
        //    dialogSystem.TalkOver();
        //}
    }

    public override void Talk()
    {
        switch (TalkNum)
        {
            case 2:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "哇...! 是一个活体狐狸...！";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 1:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "我认为紧跟着飞蛾是一个好选择";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 0:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "我听说用”R“可以回到篝火前...";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
        }
    }
}
