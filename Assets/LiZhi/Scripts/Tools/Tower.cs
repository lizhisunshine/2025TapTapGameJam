using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Tower : MonoBehaviour
{
    public float moveHigh;
    public float speed;
    //public GameObject Torch;
    public bool isUp;
    public bool isDown;

    private Vector3 upTarget;
    private Vector3 downTarget;

    public void Start()
    {
        upTarget = transform.position+Vector3.up*moveHigh;
        downTarget = transform.position;
    }
    public void Update()
    {
        if (isUp&&!isDown)
        {
            transform.position = Vector3.Lerp(transform.position, upTarget, Time.deltaTime * speed);
            if (transform.position.y >= upTarget.y - 0.1)
            {
                isUp = false;
            }
        }
        else if (isDown&&!isUp)
        {
            transform.position = Vector3.Lerp(transform.position, downTarget, Time.deltaTime * speed);
            if (transform.position.y <=downTarget.y + 0.1)
            {
                isDown = false;
            }
        }
    }
}
