using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals5 : AnimalsBase
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
                dialogSystem.ObjName = "小马";
                dialogSystem.contant = "嘘，快去找村长";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 1:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小马";
                dialogSystem.contant = "。。。";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 0:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小马";
                dialogSystem.contant = "我听说用”R“可以回到篝火前...不过这个‘R’到底是个什么东西呢...?";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
        }
    }
}
