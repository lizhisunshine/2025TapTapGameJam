using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopGameButton : MonoBehaviour
{
    [Header("这个按钮本身")]
    [SerializeField] private Button startButton;
    
    [Header("按钮启动时失活")]
    public List<GameObject> falseGameObjects;

    [Header("按钮启动时激活")]
    public List<GameObject> TrueGameObjects;//当当前ui界面消失时出现的界面

    // Start is called before the first frame update
    void Start()
    {
        startButton = this.GetComponent<Button>();
        startButton.onClick.AddListener(ButtonEffect);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonEffect();
        }
    }

    public void ButtonEffect()
    {
        for (int i = 0; i < TrueGameObjects.Count; i++)
        {
            TrueGameObjects[i].SetActive(true);
        }
        //this.gameObject.SetActive(true);

        for (int i = 0; i < falseGameObjects.Count; i++)
        {
            falseGameObjects[i].SetActive(false);
        }
        Time.timeScale = 0f;

        this.gameObject.SetActive(false);


    }
}
