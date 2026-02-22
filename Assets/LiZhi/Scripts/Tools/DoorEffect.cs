using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DoorEffect", menuName = ("itemEffects/Door Effect"))]
public class DoorEffect : ItemEffectBase
{
    //下降高度
    public float downHigh;
    public override bool Execute(GameObject user, GameObject obj)
    {
        for (int i = 0; i < user.GetComponent<ItemManager>().Keys.Count; i++)
        {
            if (obj.GetComponent<Peal>().Key == user.GetComponent<ItemManager>().Keys[i]) 
            {
                //在这里写关于门的逻辑
                //obj.transform.position += Vector3.down * downHigh;
                //user.GetComponent<ItemManager>().Keys.Remove(user.GetComponent<ItemManager>().Keys[i]);
                Destroy(obj.GetComponent<Peal>().Key);
                obj.GetComponent<Door>().isOpen = true;

                //播放音效方法
                if (effectSound != null && obj.GetComponent<AudioSource>() != null)
                { obj.GetComponent<AudioSource>().PlayOneShot(effectSound); }

                return true;
            }
        }
        return false;
    }
}
