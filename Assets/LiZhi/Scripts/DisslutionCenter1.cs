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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target&&material1)
        {
            material1.SetVector("_Center", target.position);
            material2.SetVector("_Center", target.position);
        }
    }
}
