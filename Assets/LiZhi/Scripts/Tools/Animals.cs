using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : AnimalsBase
{
    public string name;

    public DialogSystem dialogSystem;

    public void Start()
    {
        TalkNum = this.gameObject.GetComponent<Peal>().talkNum;
    }
    public void Update()
    {
        if (TalkNum <= 0)
        {
            TalkNum = 0;
        }
    }

    public override void Talk()
    {
        switch (TalkNum)
        { 
            case 0:
                dialogSystem.wordNumber = 0;
                dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小动物";
                dialogSystem.contant = "我现在在说第一句话";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 1:
                dialogSystem.wordNumber = 0;
                dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小动物";
                dialogSystem.contant = "第二句话";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 2:
                dialogSystem.wordNumber = 0;
                dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小动物";
                dialogSystem.contant = "第三句话咯~";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
        }
    }
}
