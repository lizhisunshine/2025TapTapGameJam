using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//该脚本用于动态修改溶解中心点的位置

[ExecuteAlways]
public class DisslutionCenter1 : MonoBehaviour
{
    //目标位置
    public Transform target;
    public float distance;

    public Material material1;
    public Material material2;
    
    public float normalDistance;
    //判断扩散
    public bool isDiffusion = false;
    public float maxDistance;
    //判断收缩
    public bool isShrink = false;
    public float minDistance;
    //扩散和收缩的速度
    public float Speed;
    // Start is clled before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if (target&&material1&&material2)
        {
            material1.SetVector("_Center", target.position);
            material2.SetVector("_Center", target.position);

        }
        material2.SetFloat("_Distance", distance);
        material1.SetFloat("_Distance", distance);

        if (isShrink)
        {
            distance = Mathf.Lerp(distance, minDistance, Time.deltaTime*Speed);
        }
        else if (isDiffusion)
        {
            distance = Mathf.Lerp(distance, maxDistance, Time.deltaTime * Speed);
        }
        else 
        {
            distance = Mathf.Lerp(distance, normalDistance, Time.deltaTime * Speed);
        }

    }

}
