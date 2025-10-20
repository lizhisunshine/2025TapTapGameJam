using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //玩家
    public GameObject user;
    //玩家是否拿着东西
    public bool isPickSTH;
    //玩家手上拿的东西
    public GameObject item;
    //玩家拿物体的时候 物体的偏移
    public float deltaDistance;

    //判断被使用物体是否打开
    public bool isOpen;

    //确定玩家是否死亡
    public bool isDead;
    //保存最后一个被打开的物品
    public GameObject LastObject;

    //目前能取得夜明珠的次数
    public int gitNum;

    public ItemEffectBase itemEffect;
    public ItemEffectBase lastEffect;

    // Start is called before the first frame update
    void Start()
    {
        user = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickSTH)
        {
            item.transform.position = user.transform.position+Vector3.up*deltaDistance;
        }
        if (isDead)
        {
        }
    }


}
