using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalkEffect", menuName = ("itemEffects/Talk Effect"))]
public class TalkEffect : ItemEffectBase
{
    //[Header("ÁÄÌì×î´ó¾àÀë")]
    //public float maxDistance;
    public GameObject dialogManager;
    public override bool Execute(GameObject user, GameObject obj)
    {
        //dialogManager = obj.GetComponent<AnimalsBase>().

        obj.GetComponent<AnimalsBase>().Talk();
        obj.GetComponent<AnimalsBase>().TalkNum--;
        //if ((dialogManager.GetComponent<DialogSystem>().lastAnimal = null )|| (dialogManager.GetComponent<DialogSystem>().lastAnimal != obj))
        //{
        //    dialogManager.GetComponent<DialogSystem>().lastAnimal = obj;
        //}
        if ((user.GetComponent<ItemManager>().LastAnimal == null) || (user.GetComponent<ItemManager>().LastAnimal != obj))
        {
            user.GetComponent<ItemManager>().LastAnimal = obj;
        }
        return true;
    }
}
