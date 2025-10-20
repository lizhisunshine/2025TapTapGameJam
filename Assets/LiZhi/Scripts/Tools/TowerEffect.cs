using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FrogEffect", menuName = ("itemEffects/Tower Effect"))]
public class TowerEffect :ItemEffectBase
{
    public float maxDistance;
    public override bool Execute(GameObject user, GameObject obj)
    {
        Debug.Log(user.name + "使用了道具3！");
        if (user.GetComponent<ItemManager>().isPickSTH)
        {
            user.GetComponent<ItemManager>().item.transform.position = obj.transform.position + Vector3.up * 2;
            obj.GetComponent<Peal>().item = user.GetComponent<ItemManager>().item;
            GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().isDiffusion = true ;
            user.GetComponent<ItemManager>().isPickSTH = false;
            user.GetComponent<ItemManager>().item = null;
            return true;
        }
        else if (!user.GetComponent<ItemManager>().isPickSTH)
        {
            if (obj.GetComponent<Peal>().item != null)
            {
                user.GetComponent<ItemManager>().item = obj.GetComponent<Peal>().item;
                user.GetComponentInParent<ItemManager>().isPickSTH = true;
                GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().isDiffusion = false ;
                obj.GetComponent<Peal>().item = null;
            }
        }
        return false;
    }
}
