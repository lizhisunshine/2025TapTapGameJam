using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animals2 : AnimalsBase
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
                dialogSystem.ObjName = "小鸭";
                dialogSystem.contant = "哇...! 是一个活体狐狸...！谢谢你救了我";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 2:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小鸭";
                dialogSystem.contant = "没事，这是我该做的。";
                dialogSystem.isPlayerTalk = true;
                dialogSystem.isStart = true;
                break;
            case 1:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小鸭";
                dialogSystem.contant = "作为回报，我发现点燃篝火就能得到这片区域的两张地图，还能重置夜明珠使用次数";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
            case 0:
                dialogSystem.wordNumber = 0;
                //dialogSystem.PlayerName = "主角";
                dialogSystem.ObjName = "小鸭";
                dialogSystem.contant = "下个区域和前面不太一样，似乎能旋转地形的粉色蟾蜍和扩大夜明珠范围的高塔，要注意安全";
                dialogSystem.isPlayerTalk = false;
                dialogSystem.isStart = true;
                break;
        }
    }
}
