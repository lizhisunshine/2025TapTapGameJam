using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapRotate : MonoBehaviour
{
    public GameObject mapObj;
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
            mapObj.transform.eulerAngles += new Vector3(0f,Mathf.Lerp(mapObj.transform.eulerAngles.y, targetRotate, Time.deltaTime ),0f);
            if (transform.rotation.y >= targetRotate)
            { 
                isRotate = false;
            }
        }
    }
}
