using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals4 : AnimalsBase
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
            case 3:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小牛";
                dialogSystem.contant = "哇...!";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 2:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小牛";
                dialogSystem.contant = "是一只活体狐狸";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 1:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小牛";
                dialogSystem.contant = "哇你会读心术吗？你怎么知道我要说什么？";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 0:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小牛";
                dialogSystem.contant = "你先走吧，我一会会到石板路的尽头等你，刚醒我得歇会";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
        }
    }
}
