using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public float moveHigh;
    public float speed;
    private Vector3 target;

    public bool isClose;
    public Vector3 CloseTarget;

    public void Start()
    {
        target = transform.position+Vector3.down* moveHigh;
        CloseTarget = transform.position; 

    }
    public void Update()
    {
        if (isOpen && !isClose)
        {
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speed);
            if (transform.position.y <= target.y + 0.1)
            {
                isOpen = false;
            }
        }
        else if (isClose && !isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, CloseTarget, Time.deltaTime * speed);
            if (transform.position.y >= CloseTarget.y - 0.1)
            {
                isClose = false;
            }
        }
    }
}
