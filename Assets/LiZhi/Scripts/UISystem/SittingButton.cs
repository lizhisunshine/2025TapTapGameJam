using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SittingButton : MonoBehaviour
{
    
    public GameObject SettingWindows;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(SettingWindowActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SettingWindowActive()
    {
        if (SettingWindows.activeSelf)
        {
            SettingWindows.SetActive(false);
        }
        else 
        {
            SettingWindows.SetActive(true);
        }
    }
}
