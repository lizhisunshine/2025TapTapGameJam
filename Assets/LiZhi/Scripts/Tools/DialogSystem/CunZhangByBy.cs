using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CunZhangByBy :AnimalsBase
{
    public DialogSystem dialogSystem;
    public void Start()
    {
        TalkNum = 3;
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
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "嘿，你来了";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 2:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "这么个真假虚实相交的地方，我们世世代代都住在这里";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 1:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "看样子你对这个世界有一点了解了，是吧";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 0:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "点燃六个灯笼，救出五个小动物，然后走进这个光圈里面，就可以回家了";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
        }
    }
}
