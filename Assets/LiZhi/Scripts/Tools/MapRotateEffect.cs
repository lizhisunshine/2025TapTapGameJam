using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "MapRotateEffect", menuName = ("itemEffects/MapRotate Effect"))]
public class MapRotateEffect : ItemEffectBase
{
    public override bool Execute(GameObject user, GameObject obj)
    {
        Debug.Log("使用了旋转开关！");
        //obj.GetComponent<MapRotate>().mapObj.transform.Rotate(0, 90, 0);

        //obj.GetComponent<MapRotate>().targetRotate = Quaternion.Euler(0f, obj.GetComponent<MapRotate>().mapObj.transform.rotation.y + 90, 0f);
        if (obj.GetComponent<MapRotate>().targetRotate >= 360)
            {
                obj.GetComponent<MapRotate>().targetRotate = 0;
            }
        if (!obj.GetComponent<MapRotate>().isRotate)
        {
            obj.GetComponent<MapRotate>().targetRotate = obj.GetComponent<MapRotate>().mapObjInside.transform.eulerAngles.y+90;
            //obj.GetComponent<MapRotate>().targetRotate = obj.GetComponent<MapRotate>().mapObjSurface.transform.eulerAngles.y+90;

        }
        obj.GetComponent<MapRotate>().isRotate = true;

        //播放音效方法
        if (effectSound != null && obj.GetComponent<AudioSource>() != null)
        { obj.GetComponent<AudioSource>().PlayOneShot(effectSound); }

        return true;
    }
}
