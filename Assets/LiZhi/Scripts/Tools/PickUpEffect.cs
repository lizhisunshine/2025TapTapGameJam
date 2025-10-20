using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

[CreateAssetMenu(fileName = "PickUpEffect",menuName ="itemEffects/PickUp Effect")]
public class PickUpEffect : ItemEffectBase
{
    //[Header("拾取设置")]
    //[SerializeField] private float PickDistance = 2;
    //[SerializeField] private bool isPickUp = false;
    public override bool Execute(GameObject user, GameObject obj)
    {
        Debug.Log(user.name+"使用了道具1！");
        if (user.GetComponent<ItemManager>().isPickSTH)
        {
            Debug.Log("放下了物体");
            user.GetComponent<ItemManager>().lastEffect = null;

        }
        else
        {
            Debug.Log("拿起了物体");
            user.GetComponent<ItemManager>().item = obj;
        }


        user.gameObject.GetComponent<ItemManager>().isPickSTH = !user.gameObject.GetComponent<ItemManager>().isPickSTH;
        return true;
    }

}
