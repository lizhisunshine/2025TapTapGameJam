using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialStartGame : MonoBehaviour
{
    [Header("这个按钮本身")]
    [SerializeField] private Button startButton;

    //[Header("按钮启动时失活")]
    //public List<GameObject> falseObjs;
    [Header("按钮启动时激活")]
    public List<GameObject> trueObjs;//当当前ui界面消失时出现的界面

    public GameObject Tutorial;

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
        Time.timeScale = 1f;
        for (int i = 0; i < trueObjs.Count; i++)
        {
            trueObjs[i].SetActive(true);
        }
        Tutorial.SetActive(false);


    }
}
