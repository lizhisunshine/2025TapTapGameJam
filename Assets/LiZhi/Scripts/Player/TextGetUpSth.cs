using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class TextFineBar : MonoBehaviour
{
    public GameObject Sth;
    public float speed;
    public  bool isPicekUp;
    // Start is called before the first frame update
    void Start()
    {
        isPicekUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isPicekUp)
            { 
            isPicekUp = false;
            }
            else if (!isPicekUp)
            { 
            isPicekUp = true;
            }
        }

        if (isPicekUp)
        {
            Sth.transform.position = math.lerp(Sth.transform.position, transform.position + Vector3.up * 2,Time.deltaTime*speed);
        }

    }
}
