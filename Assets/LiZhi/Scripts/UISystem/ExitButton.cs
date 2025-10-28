using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(ExitGame);
            }
    // Update is called once per frame
    void Update()
    {

    }

    void ExitGame()
    {
        Debug.Log("游戏已经退出！");
        Application.Quit();
    }
}
