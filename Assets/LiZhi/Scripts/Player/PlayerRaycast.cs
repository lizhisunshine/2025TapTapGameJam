using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public Ray r ;
    RaycastHit hitinfo;
    public float rayLength;
    public GameObject player;

    //记录上一个检测到的物体，用于是否出现白边判定
    [SerializeField] GameObject LastObj;

    public void Start()
    {
    }

    public void Update()
    {

        //申明射线并画出
        r = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.green);
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (Physics.Raycast(r, out hitinfo, rayLength, 1 << LayerMask.NameToLayer("Item")))
            {
                Peal peal = hitinfo.collider.gameObject.GetComponent<Peal>();
                ItemEffectBase ib = peal.ItemEffect;
                //if (player.GetComponent<ItemManager>().itemEffect != null)
                //{
                //    player.GetComponent<ItemManager>().lastEffect = player.GetComponent<ItemManager>().itemEffect;
                //}
                //player.GetComponent<ItemManager>().itemEffect = ib;

                //if (player.GetComponent<ItemManager>().itemEffect is PedestalEffext)
                //{
                //    if (player.GetComponent<ItemManager>().lastEffect is PickUpEffect && player.GetComponent<ItemManager>().item != null)
                //    {
                //        peal.useTool();
                //    }
                //}
                //else
                //{
                //    peal.useTool();
                //}

                peal.useTool();


            }
            else if (player.GetComponent<ItemManager>().item != null)
            {
                player.GetComponent<ItemManager>().item.GetComponent<Peal>().useTool();
                player.GetComponent<ItemManager>().item = null;
            }
        }

        //白边逻辑

        if (Physics.Raycast(r, out hitinfo, rayLength, 1 << LayerMask.NameToLayer("Item")) && LastObj == null)
        {
            hitinfo.collider.GetComponent<Outline>().enabled = true;
            LastObj = hitinfo.collider.gameObject;
        }
        else if (Physics.Raycast(r, rayLength, 1 << LayerMask.NameToLayer("Item")) && LastObj != null)
        {
            if (hitinfo.collider.gameObject != LastObj)
            {
                LastObj.GetComponent<Outline>().enabled = false;
                hitinfo.collider.GetComponent<Outline>().enabled = true;
                LastObj = hitinfo.collider.gameObject;
            }
            else 
            {
                hitinfo.collider.GetComponent<Outline>().enabled = true;
            }
        }
        else if (LastObj != null)
        {
            LastObj.GetComponent<Outline>().enabled = false;
        }

        

    }

}
