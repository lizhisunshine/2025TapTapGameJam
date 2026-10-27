using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeBye : AnimalsBase
{
    public DialogSystem dialogSystem;
    public void Start()
    {
        TalkNum = 1;
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
            case 10:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "哇...! 是一个活体狐狸...！你是怎么来到这里的？";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 9:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "我也不太清楚，好像刚才我还在上课，一转眼就在这了";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 8:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "竟然不明不白来到这么危险的地方了吗";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 7:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "这里最近很不太平，我建议你还是离开这个地方";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 6:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "您说的有道理，这看着就不太安全。我应该怎样才能离开？";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 5:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "去找除我之外的五只小动物，它们被困在这个森林各处的灯笼里面了";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 4:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "找到它们，然后走到石板路的另一侧，我们就能帮你回家。";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 3:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "感谢你能跟我说这些";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 2:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "村长";
                dialogSystem.contant = "不用谢，如果你不知道该去哪里了，就跟随飞虫的脚步，这些小东西会给你指明方向。";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;

            case 1:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "大家";
                dialogSystem.contant = "你要走了吗？";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 0:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "大家";
                dialogSystem.contant = "祝你在自己的世界也要开心哦";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
        }
    }

}
