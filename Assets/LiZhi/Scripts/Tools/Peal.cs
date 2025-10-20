using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peal : MonoBehaviour
{
    public ItemEffectBase ItemEffect;
    public  GameObject player;
    public bool isPickUp;

    //针对 塔 等需要将物品放上去的道具 传入的物体信息
    public GameObject item;
    //针对 青蛙 等需要创建预制体的道具 传入的预制体信息
    public GameObject prefab;
    //针对 旋转机关 等需要和地图联动的道具 传入的地图场景信息
    //public GameObject map;

    public void useTool()
    {
        ItemEffect.Execute(player,this.gameObject);
    }

}
