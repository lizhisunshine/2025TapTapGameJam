using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public int ClickNum;
    public List<GameObject> images;
    public List <GameObject> buttons;
    // Start is called before the first frame update
    void Start()
    {
        ClickNum = 0;
        this.GetComponent<Button>().onClick.AddListener(EndFunc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndFunc()
    {
        //switch(ClickNum)
        //{
        //    case 0:
        //        images[1].SetActive(true);
        //        break;
        //    case 1:
        //        break;
        //    case 2:
        //        break;
        //    case 3:
        //        break;
        //}
        images[ClickNum].SetActive(true);
        ClickNum++;
        if (ClickNum >= 4)
        {
            for (int i = 0; i < buttons.Count; i++) 
            {
            buttons[i].SetActive(true);
            }
            ClickNum=3;
        }
    }
}
