using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals : AnimalsBase
{
    //public string name;

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
        //Debug.Log("animal和玩家距离为："+Vector3.Distance(this.gameObject.transform.position, this.GetComponent<Peal>().player.transform.position));
        //if (Vector3.Distance(this.gameObject.transform.position, this.GetComponent<Peal>().player.transform.position) >= dialogSystem.maxDistance)
        //{
        //    dialogSystem.TalkOver();
        //}
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

    public override void TalkOver()
    { 
        dialogSystem.TalkOver();    
    }
}
