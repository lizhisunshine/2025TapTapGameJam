using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapImage : MonoBehaviour
{
    //存储当前里世界地图
    public GameObject InsideMapImage;
    //存储当前表世界地图
    public GameObject SurfaceMapImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InsideMapImage && SurfaceMapImage)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (InsideMapImage.activeSelf)
                {
                    InsideMapImage.SetActive(false);
                }
                else 
                {
                    InsideMapImage.SetActive(true);
                }
                if (SurfaceMapImage.activeSelf)
                {
                    SurfaceMapImage.SetActive(false);
                }
                else
                {
                    SurfaceMapImage.SetActive(true);
                }
            }
        }
        else 
        {
            this.gameObject.SetActive(false);
        }
    }
}
