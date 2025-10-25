using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peal : MonoBehaviour
{
    public ItemEffectBase ItemEffect;
    public  GameObject player;
    public bool isPickUp;

    //针对 塔 等需要将物品放上去的道具 传入的物体信息
    [Header("针对 塔 等")]
    public GameObject item;
    //针对 青蛙 等需要创建预制体的道具 传入的预制体信息
    [Header("针对 青蛙 等")]
    public GameObject prefab;
    //针对 门 等需要和钥匙配对的道具 传入的钥匙信息 
    [Header("针对 门 等")]
    public GameObject Key;
    //针对 篝火 等需要和门配对的道具 传入的门信息
    [Header("针对 篝火 等")]
    public GameObject door;
    /// <summary>
    /// 储存每个篝火对应关卡的夜明珠销毁次数
    /// </summary>
    public int LevelNum;
    [Header("针对 灯笼 等")]
    //判断当前灯笼是否被点亮
    public bool isOn;

    [Header("针对 告示牌 等")]
    public int NeedsNum;

    //玩家和这个物体的对话计数器
    [Header("针对 动物 等")]
    public int talkNum;

    public void useTool()
    {
        ItemEffect.Execute(player,this.gameObject);

    }

}
