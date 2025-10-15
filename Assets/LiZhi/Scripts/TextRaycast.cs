using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRaycast : MonoBehaviour
{
    Ray r;
    RaycastHit hitinfo;
    public float RayLength;

    public bool isPickUp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        r = new Ray(transform.position, transform.forward);


        Debug.DrawRay(transform.position, transform.forward * RayLength, Color.green);

        if (Physics.Raycast(r, out hitinfo, RayLength, 1 << LayerMask.NameToLayer("InteractiveObjects")))
        {
            Debug.Log("碰撞物体，得到了信息");
            print(hitinfo.collider.gameObject.name);
            hitinfo.collider.gameObject.GetComponent<Outline>().enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                isPickUp = true;
            }

        }

    }


}
