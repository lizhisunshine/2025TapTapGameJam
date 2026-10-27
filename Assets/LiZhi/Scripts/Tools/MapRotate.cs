using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapRotate : MonoBehaviour
{
    public GameObject mapObjSurface;
    public GameObject mapObjInside;
    //正在旋转的时候不能再次旋转
    public bool isRotate = false;
    //目标角度
    public float targetRotate;
    //旋转速度
    public float speed;
    void Update()
    {
        if (isRotate == true)
        {
            //mapObj.transform.eulerAngles = new Vector3(0f,Mathf.Lerp(mapObj.transform.eulerAngles.y, targetRotate, Time.deltaTime*speed ),0f);
            Quaternion targetRotation = Quaternion.Euler(0f, targetRotate, 0f);
            mapObjSurface.transform.rotation = Quaternion.RotateTowards(mapObjSurface.transform.rotation, targetRotation, speed * Time.deltaTime);
            mapObjInside.transform.rotation = Quaternion.RotateTowards(mapObjInside.transform.rotation, targetRotation, speed * Time.deltaTime);

            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, targetRotation, speed * Time.deltaTime);

            //if (mapObj.transform.eulerAngles.y >= targetRotate)
            //{

            //    isRotate = false;
            //}
            targetRotation = Quaternion.Euler(0f, targetRotate, 0f);
            if (Quaternion.Angle(mapObjSurface.transform.rotation, targetRotation) <= 1f)
            {
                isRotate = false;
                mapObjSurface.transform.rotation = targetRotation;
            }
            if (Quaternion.Angle(mapObjInside.transform.rotation, targetRotation) <= 1f)
            {
                isRotate = false;
                mapObjInside.transform.rotation = targetRotation;
            }

        }
    }
}
