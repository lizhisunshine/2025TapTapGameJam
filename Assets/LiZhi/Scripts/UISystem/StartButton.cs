using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [Header("这个按钮本身")]
    [SerializeField] private Button startButton;

    public GameObject Tutorial;


    [Header("按钮启动时失活")]
    public List<GameObject> falseObjs;
    //[Header("按钮启动时激活")]
    //public List<GameObject> trueObjs;//当当前ui界面消失时出现的界面


    // Start is called before the first frame update
    void Start()
    {
        startButton = this.GetComponent<Button>();
        Time.timeScale = 0f;
        startButton.onClick.AddListener(StartEffect);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            StartEffect();
        }
    }

    public void StartEffect()
    {
        //Time.timeScale = 1f;
        //for (int i = 0; i < trueObjs.Count; i++)
        //{
        //    trueObjs[i].SetActive(true);
        //}
        //this.gameObject.SetActive(true);
        Tutorial.SetActive(true);

        for (int i = 0; i < falseObjs.Count; i++)
        {
            falseObjs[i].SetActive(false);
        }
        this.gameObject.SetActive(false);


    }


}
