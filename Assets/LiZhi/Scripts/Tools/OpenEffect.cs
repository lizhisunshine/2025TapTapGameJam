using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="OpenEffects",menuName ="itemEffects/Open Effect")]
public class OpenEffect : ItemEffectBase
{
    public override bool Execute(GameObject user, GameObject obj)
    {
        Debug.Log(user.name + "使用了道具2！");
        
        return true;
    }

}
