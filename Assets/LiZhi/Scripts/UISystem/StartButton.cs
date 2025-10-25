using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button startButton;

    public List<GameObject> buttons;

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
        
    }

    public void StartEffect()
    { 
        Time.timeScale = 1f;
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
