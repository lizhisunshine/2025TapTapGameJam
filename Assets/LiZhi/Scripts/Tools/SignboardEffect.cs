using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SignboardEffect", menuName = ("itemEffects/Signboard Effect"))]
public class SignboardEffect :ItemEffectBase
{
    public override bool Execute(GameObject user, GameObject obj)
    {
        if (obj.GetComponent<Peal>().NeedsNum <= user.GetComponent<ItemManager>().LightUpNum)
        {
            Debug.Log("解除了木牌");
            obj.SetActive(false);
        }
        else 
        {
            string str = "要进入这里还需要解救"+(obj.GetComponent<Peal>().NeedsNum - user.GetComponent<ItemManager>().LightUpNum)+"个小动物";
            Debug.Log(str);
        }
        return true;
    }
}
