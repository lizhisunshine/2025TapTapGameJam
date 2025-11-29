using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LanternEffect", menuName = ("itemEffects/Lantern Effect"))]
public class LanternEffect : ItemEffectBase
{
    public int OnNum;

    public GameObject Flys;
    private int i;
    public void OnEnable()
    {
        OnNum = 0;
        Flys = GameObject.Find("particle (1)");
    }
    public override bool Execute(GameObject user, GameObject obj)
    {
        i = Flys.GetComponent<Insect>().i;
        if ((i == 4 || i == 11 || i == 17 || i == 23 || i == 29 || i == 36))
        {

            if (obj.GetComponent<Peal>().isOn == false)
            {
                Flys.GetComponent<Insect>().isLightOn = true;
                

                OnNum++;
                obj.GetComponent<Peal>().isOn = true;
                user.GetComponent<ItemManager>().LightUpNum = OnNum;

                //ÐÞ¸Äµ±Ç°µÆÁý×´Ì¬
                obj.GetComponent<Light>().enabled = true;

                if (obj.GetComponent<Peal>().Animal != null)
                {
                    obj.GetComponent<Peal>().Animal.SetActive(true);
                }
            }
        }

        return true;
    }
}
