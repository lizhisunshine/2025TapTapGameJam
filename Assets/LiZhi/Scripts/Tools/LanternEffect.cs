using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LanternEffect", menuName = ("itemEffects/Lantern Effect"))]
public class LanternEffect : ItemEffectBase
{
    public int OnNum;
    public void OnEnable()
    {
        OnNum = 0;
    }
    public override bool Execute(GameObject user, GameObject obj)
    {
        if (obj.GetComponent<Peal>().isOn == false) 
        {
            OnNum++;
            obj.GetComponent<Peal>().isOn = true;
            user.GetComponent<ItemManager>().LightUpNum = OnNum;

            //ÐÞ¸Äµ±Ç°µÆÁý×´Ì¬
            obj.GetComponent<Light>().enabled = true;
        }

        return true;
    }
}
