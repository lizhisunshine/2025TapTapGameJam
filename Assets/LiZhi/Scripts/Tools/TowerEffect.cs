using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "FrogEffect", menuName = ("itemEffects/Tower Effect"))]
public class TowerEffect :ItemEffectBase
{
    public float torchSoffet;
    public override bool Execute(GameObject user, GameObject obj)
    {
        Debug.Log(user.name + "使用了高塔！");
        if (user.GetComponent<ItemManager>().isPickSTH)
        {
            user.GetComponent<ItemManager>().item.transform.position = obj.transform.position + Vector3.up * torchSoffet;
            obj.GetComponent<Peal>().item = user.GetComponent<ItemManager>().item;

            obj.GetComponent <Peal>().item.GetComponent<Collider>().enabled = false;
            obj.GetComponent<Peal>().item.GetComponent<Rigidbody>().useGravity = false;
            obj.GetComponent<Peal>().item.GetComponent<Rigidbody>().velocity= Vector3.zero;

            obj.GetComponent<Peal>().item.transform.parent = obj.transform;

            obj.GetComponent<Tower>().isUp = true;
            obj.GetComponent<Tower>().isDown = false;

            GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().isDiffusion = true ;
            user.GetComponent<ItemManager>().isPickSTH = false;
            user.GetComponent<ItemManager>().item = null;

            //播放音效方法
            if (effectSound != null && obj.GetComponent<AudioSource>() != null)
            { obj.GetComponent<AudioSource>().PlayOneShot(effectSound); }

            return true;
        }
        else if (!user.GetComponent<ItemManager>().isPickSTH)
        {
            if (obj.GetComponent<Peal>().item != null)
            {
                user.GetComponent<ItemManager>().item = obj.GetComponent<Peal>().item;
                user.GetComponentInParent<ItemManager>().isPickSTH = true;

                obj.GetComponent<Peal>().item.GetComponent<Collider>().enabled = true;
                obj.GetComponent<Peal>().item.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<Peal>().item.transform.parent = null;

                obj.GetComponent<Tower>().isUp = false;
                obj.GetComponent<Tower>().isDown = true;

                GameObject.Find("CenterPointController").GetComponent<DisslutionCenter1>().isDiffusion = false ;
                obj.GetComponent<Peal>().item = null;

                //播放音效方法
                if (effectSound != null && obj.GetComponent<AudioSource>() != null)
                { obj.GetComponent<AudioSource>().PlayOneShot(effectSound); }
            }
        }
        return false;
    }
}
