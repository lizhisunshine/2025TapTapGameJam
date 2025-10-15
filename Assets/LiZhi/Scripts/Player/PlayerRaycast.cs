using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    Ray r ;
    RaycastHit hitinfo;
    public float RayLength;
    [SerializeField]
    private GameObject LastObj;

    public bool isPickUp;
    // Start is called before the first frame update
    void Start()
    {
       isPickUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        //申明射线并画出
        r = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward*RayLength,Color.green);

        if (!isPickUp)
        {
            if (Physics.Raycast(r, out hitinfo, RayLength, 1 << LayerMask.NameToLayer("InteractiveObjects")))
            {
                print("碰撞物体，得到了信息");
                print(hitinfo.collider.gameObject.name);
                LastObj = hitinfo.collider.gameObject;
                LastObj.GetComponent<Outline>().enabled = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    isPickUp = true ;
                }

            }
        }
        else if (isPickUp)
        {
            //hitinfo.collider.gameObject.GetComponent<Outline>().enabled = true;
            print(hitinfo.collider.gameObject.name + "开始工作");
            LastObj.GetComponent<Outline>().enabled = false;
            LastObj.GetComponent<BaseTool>().Work();
            if (Input.GetKeyDown(KeyCode.E))
            {
                isPickUp = false;
            }
        }

        if (!Physics.Raycast(r, RayLength, 1 << LayerMask.NameToLayer("InteractiveObjects"))&&LastObj!=null)
        { 
            LastObj.GetComponent<Outline>().enabled = false;
        }
        if (Physics.Raycast(r, RayLength, 1 << LayerMask.NameToLayer("InteractiveObjects")) && LastObj != null)
        {
            if (hitinfo.collider.gameObject != LastObj) 
            {
                LastObj.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
