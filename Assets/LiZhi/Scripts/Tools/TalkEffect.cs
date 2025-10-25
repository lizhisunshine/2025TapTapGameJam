using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkEffect", menuName = ("itemEffects/Talk Effect"))]
public class TalkEffect : ItemEffectBase
{
    public override bool Execute(GameObject user, GameObject obj)
    {
        obj.GetComponent<AnimalsBase>().Talk();
        obj.GetComponent<AnimalsBase>().TalkNum--;

        return true;
    }
}
