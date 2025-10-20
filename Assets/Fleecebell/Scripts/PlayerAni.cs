using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAni : MonoBehaviour
{
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.speed = 1.4f;
            }
            else
            {
                anim.speed = 1f;
            }
        }
        else
        {
            anim.SetBool("isWalk", false);
        }

        
    }
}
