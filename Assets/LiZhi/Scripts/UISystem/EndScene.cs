using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public GameObject p0;
    public Transform p0_target;
    public GameObject p1;
    public Transform p1_target;
    public GameObject p2;
    public Transform p2_target;
    public GameObject p3;
    public Transform p3_target;
    public float speed = 10f;

    public GameObject button;
    private AudioSource AudioSource;

    public int ClickNum;
    //public List<GameObject> images;
    //public List <GameObject> buttons;
    // Start is called before the first frame update
    void Start()
    {
        ClickNum = 0;
        AudioSource = GetComponent<AudioSource>();
        //this.GetComponent<Button>().onClick.AddListener(EndFunc);
    }

    // Update is called once per frame
    void Update()
    {
        if (ClickNum == 1)
        {
            p0.transform.position = Vector3.Lerp(p0.transform.position, p0_target.position, Mathf.Min(speed * Time.deltaTime, 1f));
            if(Input .GetMouseButtonDown(0)) AudioSource.Play();
        }
        if (ClickNum == 2)
        {
            p1.transform.position = Vector3.Lerp(p1.transform.position, p1_target.position, Mathf.Min(speed * Time.deltaTime, 1f));
            if (Input.GetMouseButtonDown(0)) AudioSource.Play();
        }
        if (ClickNum == 3)
        {
            p2.transform.position = Vector3.Lerp(p2.transform.position, p2_target.position, Mathf.Min(speed * Time.deltaTime, 1f));
            if (Input.GetMouseButtonDown(0)) AudioSource.Play();
        }
        if (ClickNum == 4)
        {
            p3.transform.position = Vector3.Lerp(p3.transform.position, p3_target.position, Mathf.Min(speed * Time.deltaTime, 1f));
            if (Input.GetMouseButtonDown(0)) AudioSource.Play();
        }
        if(ClickNum == 5)
        {
            button.SetActive(true);
        }
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
        //images[ClickNum].SetActive(true);
        ClickNum++;

        //if (ClickNum > 4)
        //{
        //    for (int i = 0; i < buttons.Count; i++) 
        //    {
        //    buttons[i].SetActive(true);
        //    }
        //    ClickNum=3;
        //}
    }
}
