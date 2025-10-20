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

        if (!obj.GetComponent<MapRotate>().isRotate)
        {
            obj.GetComponent<MapRotate>().targetRotate = obj.GetComponent<MapRotate>().mapObj.transform.eulerAngles.y+90;
        }
        obj.GetComponent<MapRotate>().isRotate = true;

        return true;
    }
}
