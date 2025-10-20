using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "FrogEffect", menuName = ("itemEffects/Frog Effect"))]
public class FrogEffext : ItemEffectBase
{
    public bool isHadPick = false;

    public override bool Execute(GameObject user, GameObject obj)
    {
        Debug.Log(user.name + "使用了道具3！");
        if (user.GetComponent<ItemManager>().isPickSTH&&isHadPick)
        {
            //user.GetComponent<ItemManager>().item.transform.position = obj.transform.position + Vector3.up * 2;
            //obj.GetComponent<Peal>().item = user.GetComponent<ItemManager>().item;
            GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().isShrink = true;
            user.GetComponent<ItemManager>().isPickSTH = false;
            Destroy(user.GetComponent<ItemManager>().item);
            user.GetComponent<ItemManager>().item = null;
            //user.GetComponent<ItemManager>().item = null;
            isHadPick = false;
            return true;
        }
        else if (!user.GetComponent<ItemManager>().isPickSTH&&!isHadPick)
        {
            Debug.Log(user.name + "正在生成预制体");
            //user.GetComponent<ItemManager>().item = obj.GetComponent<Peal>().item;
            //user.GetComponentInParent<ItemManager>().isPickSTH = true;
            //obj.GetComponent<Peal>().item = null;
            GameObject instance = (GameObject)Instantiate(obj.GetComponent<Peal>().prefab);
            user.GetComponent<ItemManager>().item = instance;
            GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().target = instance.transform;
            GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().isShrink = false;
            user.GetComponent<ItemManager>().isPickSTH = true;
            isHadPick =true;
            
        }
        return false;
    }

}
