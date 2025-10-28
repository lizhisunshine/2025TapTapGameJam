using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogInfoUI : MonoBehaviour
{
    public GameObject player;
    public int FrogNum;
    //需要显示的图片
    public List<GameObject> FrogImageList;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        FrogNum = player.GetComponent<ItemManager>().gitNum;
        for (int i = 0; i < FrogImageList.Count; i++)
        {
            FrogImageList[i].gameObject.SetActive(false);
        }
        FrogImageList[FrogNum-1].SetActive(true);


    }
}
