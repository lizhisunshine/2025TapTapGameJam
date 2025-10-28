using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FireEffect", menuName = ("itemEffects/Fire Effect"))]
public class FireEffect : ItemEffectBase
{
    [SerializeField]private GameObject LastFire;

    [SerializeField] private GameObject LastDoor;

    //地图ui
    public GameObject MapUI;

    public void OnEnable()
    {
        LastFire = LastDoor = null;
        MapUI = GameObject.Find("MapImage");
    }
    public override bool Execute(GameObject user, GameObject obj)
    {
        //if(!obj.GetComponent<Peal>().door.GetComponent<Door>().isOpen&& !obj.GetComponent<Peal>().door.GetComponent<Door>().isClose)
        if (LastFire == null)
        {             
            user.GetComponent<ItemManager>().Fire = obj;
            LastFire = obj;

            user.GetComponent<ItemManager>().nowLevelNum = obj.GetComponent<Peal>().LevelNum;
            user.GetComponent<ItemManager>().gitNum = user.GetComponent<ItemManager>().nowLevelNum;

            obj.GetComponent<Peal>().door.GetComponent<Door>().isOpen = true;

            obj.transform.GetChild(0).gameObject.SetActive(false);
            obj.transform.GetChild(1).gameObject.SetActive(true);
            //播放音效方法
            if (effectSound != null && obj.GetComponent<AudioSource>() != null) 
            { obj.GetComponent<AudioSource>().PlayOneShot(effectSound); }
            //obj.GetComponent<AudioSource>().PlayOneShot(effectSound);

            //更新ui地图的方法
            MapUI.GetComponent<MapImage>().InsideMapImage = obj.GetComponent<Peal>().levelInsideMap;
            MapUI.GetComponent<MapImage>().InsideMapImage.SetActive(false);
            MapUI.GetComponent<MapImage>().SurfaceMapImage = obj.GetComponent<Peal>().levelSurfaceMap;
            MapUI.GetComponent<MapImage>().InsideMapImage.SetActive(true);

        }
        if (LastFire != null)
        {
            if (obj != user.GetComponent<ItemManager>().Fire)
            {
                user.GetComponent<ItemManager>().Fire.transform.GetChild(0).gameObject.SetActive(true);
                user.GetComponent<ItemManager>().Fire.transform.GetChild(1).gameObject.SetActive(false);
                obj.transform.GetChild(0).gameObject.SetActive(false);
                obj.transform.GetChild(1).gameObject.SetActive(true);

                user.GetComponent<ItemManager>().Fire.GetComponent<Peal>().door.GetComponent<Door>().isClose = true;
                obj.GetComponent<Peal>().door.GetComponent <Door>().isOpen = true;

                LastFire = user.GetComponent<ItemManager>().Fire;
                user.GetComponent<ItemManager>().Fire = obj;

                user.GetComponent<ItemManager>().nowLevelNum = obj.GetComponent<Peal>().LevelNum;
                user.GetComponent<ItemManager>().gitNum = user.GetComponent<ItemManager>().nowLevelNum;

                //播放音效方法
                if (effectSound != null && obj.GetComponent<AudioSource>() != null)
                { obj.GetComponent<AudioSource>().PlayOneShot(effectSound); }

                //更新ui地图的方法
                MapUI.GetComponent<MapImage>().InsideMapImage = obj.GetComponent<Peal>().levelInsideMap;
                MapUI.GetComponent<MapImage>().InsideMapImage.SetActive(false);
                MapUI.GetComponent<MapImage>().SurfaceMapImage = obj.GetComponent<Peal>().levelSurfaceMap;
                MapUI.GetComponent<MapImage>().InsideMapImage.SetActive(true);
            }
        }
        
        return true;
    }
}
