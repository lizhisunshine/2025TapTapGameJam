using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//该脚本用于动态修改溶解中心点的位置

[ExecuteAlways]
public class DisslutionCenter1 : MonoBehaviour
{
    //目标位置
    public Transform target;

    public Material material1;
    public Material material2;

    public Material[] materials1;
    public Material[] materials2;

    void Start()
    {
        
    }


    void Update()
    {
        if (target && materials1.Length > 0 && materials2.Length > 0)
        {
            material1.SetVector("_Center", target.position);
            material2.SetVector("_Center", target.position);
            for (int i = 0; i < materials1.Length; i++)
            {
                materials1[i].SetVector("_Center", target.position);
            }
            for (int i = 0; i < materials2.Length; i++)
            {
                materials2[i].SetVector("_Center", target.position);
            }
        }
    }
}
