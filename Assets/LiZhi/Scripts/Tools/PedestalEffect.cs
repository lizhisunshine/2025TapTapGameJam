using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "PedestalEffect",menuName =("itemEffects/Pedestal Effect"))]
public class PedestalEffext : ItemEffectBase
{
    public override bool Execute(GameObject user, GameObject obj)
    {
        Debug.Log(user.name + "Ê¹ÓÃÁËµ××ù£¡");
        if (user.GetComponent<ItemManager>().isPickSTH)
        {
            user.GetComponent<ItemManager>().item.transform.position = obj.transform.position + Vector3.up * 2;
            obj.GetComponent<Peal>().item = user.GetComponent<ItemManager>().item;
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
                obj.GetComponent<Peal>().item = null;
            }
        }
        return false;
    }

}
