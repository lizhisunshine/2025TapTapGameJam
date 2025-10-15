using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteAlways]
//该脚本用于让两个不同世界的渲染距离相等
public class Mapchange : MonoBehaviour
{
    public float distance;

    public Material material1;

    public Material material2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        material2.SetFloat("_Distance", distance);
        material1.SetFloat("_Distance", distance);

    }
}
